import { Component, OnInit, OnDestroy } from '@angular/core';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from '../models/Category';
import { Title, Meta } from '@angular/platform-browser';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
})
export class PostListComponent implements OnInit, OnDestroy{
  

  public posts: Post[];
  public errorMessage;
  public successMessage;
  public cityId: number;
  public categoryId: number;
  public content: string;
  public postId: number;
  private subscription: Subscription;
  currentCategory: Category;
  currentPost: Post;
  private showCategory = true;
  private showPost = false;

  private criteria: PostSearchCriteria = {
    fromPostId: null,
    titleContain: null,
    cityId: null,
    categoryId: null
  };

  constructor(private titleService: Title, private metaService: Meta,private service: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    //this.subscription = this.service.notifyObservable$.subscribe((criteria: PostSearchCriteria) => {
     

    //  this.currentCategory = this.service.searchCategory;
    //  if (this.currentCategory) {
    //    const title = this.currentCategory.name + ' | Rao Vặt Việt Mỹ - đăng tin miễn phí - Classified Ads';
    //    this.titleService.setTitle(title);
    //    this.metaService.updateTag({ name: 'keywords', content: title });
    //    this.metaService.updateTag({ name: 'description', content: title });

    //  }

    //  if (!criteria) this.getPosts();
    //  else this.searchPosts(criteria);
    //});
    let kind = "search";

    this.route.data.subscribe(data => {
      kind = data.kind;
    });

    if (kind == "category") {
      this.route.paramMap.subscribe(params => {
        this.categoryId = +params.get('categoryId');
        let categoryDescription = params.get('categoryDescription');

        if (this.categoryId) {
          this.showCategory = false;
          this.criteria.categoryId = this.categoryId;
          this.currentCategory = new Category();
          this.currentCategory.name = categoryDescription;
          this.currentCategory.id = this.categoryId;

          const title = categoryDescription + ' | Rao Vặt Việt Mỹ - đăng tin miễn phí - Classified Ads';
          this.titleService.setTitle(title);
          this.metaService.updateTag({ name: 'keywords', content: title });
          this.metaService.updateTag({ name: 'description', content: title });
          this.searchPosts(this.criteria);
        }
      });
    }
    else if (kind == "search"){
      this.subscription = this.service.notifyObservable$.subscribe((criteria: PostSearchCriteria) => {

      this.criteria = { ...criteria };
      this.currentCategory = this.service.searchCategory;
      if (this.currentCategory) {
        const title = this.currentCategory.name + ' | Rao Vặt Việt Mỹ - đăng tin miễn phí - Classified Ads';
        this.titleService.setTitle(title);
        this.metaService.updateTag({ name: 'keywords', content: title });
        this.metaService.updateTag({ name: 'description', content: title });
        }
        if (!criteria) this.getPosts();
        else this.searchPosts(criteria);
    });
    }

    else if (kind == "post") {
      this.route.paramMap.subscribe(params => {
        this.postId = +params.get('postId');
        let postTitle = params.get('postTitle');

        if (this.postId) {
          this.showCategory = false;
          this.showPost = true;
          
          //this.criteria.categoryId = this.categoryId;
          //this.currentCategory = new Category();
          //this.currentCategory.name = categoryDescription;
          //this.currentCategory.id = this.categoryId;

          const title = postTitle + ' | Rao Vặt Việt Mỹ - đăng tin miễn phí - Classified Ads';
          this.titleService.setTitle(title);
          this.metaService.updateTag({ name: 'keywords', content: title });
          this.metaService.updateTag({ name: 'description', content: title });

          this.getPostDetail(this.postId);
          
        
        }
      });
    }
  }

  searchCriteriaChange(criteria: PostSearchCriteria) {
    if (criteria) {
      this.criteria.titleContain = criteria.titleContain;
      this.criteria.cityId = criteria.cityId;
      this.searchPosts(this.criteria);
    }
  }

  ngOnDestroy(): void {
    //this.subscription.unsubscribe();
  }

  getPosts() {
    this.service.getLatestPosts()
      .subscribe(data => {
        this.posts = data;
        this.searchPosts(this.criteria);
        this.successMessage = `(${this.posts.length} items)`;
      }, error => {
          this.errorMessage = error;
      }
      );
  }

  searchPosts(criteria: PostSearchCriteria) {
    this.service.searchLatest(criteria)
      .subscribe(data => {
        this.posts = data;
        this.successMessage = `(${this.posts.length} items)`;
      }, error => {
        this.errorMessage = error;
      }
      );
  }

  getPostDetail(postId: number) {
    this.service.getPost(postId)
      .subscribe(data => {
        this.currentPost = data;
        this.criteria.categoryId = this.currentPost.categoryId;

        this.currentCategory = new Category();
        this.currentCategory.name = this.currentPost.category;
        this.categoryId = this.currentPost.categoryId;
        this.currentCategory.id = this.currentPost.categoryId;

        this.searchPosts(this.criteria);
        this.successMessage = 'Success';
      }, error => {
        this.errorMessage = error;
      }
      );
  }

  loadMore() {
    if (this.posts && this.posts.length > 0) {
      let lastPostId = this.posts[this.posts.length - 1].id;
      let criteria = { ...this.criteria, fromPostId: lastPostId };
    
      this.service.searchLatest(criteria)
        .subscribe(data => {
          this.posts= this.posts.concat(data);
          this.successMessage = `(${this.posts.length} items)`;
        }, error => {
          this.errorMessage = error;
        }
        );
    }
  }

  //urlFriendly(str) {
  //  var url = str.substr(0, 200);
  //  return this.service.removeAccents(url).replace(/[^a-zA-Z0-9]/g, '-').replace(/--+/g, '-');
  //}

  onCategoryReset() {
    this.service.searchCategoryId = null;
  }

  onToggleCategory() {
    this.showCategory = !this.showCategory;
  }
}

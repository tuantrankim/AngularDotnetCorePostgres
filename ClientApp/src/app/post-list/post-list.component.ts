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
  constructor(private titleService: Title, private metaService: Meta, private service: PostService, private route: ActivatedRoute) { }
  ngOnInit() {
    

    this.subscription = this.service.notifyObservable$.subscribe((criteria: PostSearchCriteria) => {
      if(!criteria) this.getPosts();
      else this.searchPosts(criteria);

      this.currentCategory = this.service.searchCategory;
      if (this.currentCategory) {
        const title = this.currentCategory.name + ' | Rao Vặt Việt Mỹ - đăng tin miễn phí - Classified Ads';
        this.titleService.setTitle(title);
        this.metaService.updateTag({ name: 'keywords', content: title });
        this.metaService.updateTag({ name: 'description', content: title });
      }
    });

     this.route.paramMap.subscribe(params => {
       this.cityId = +params.get('cityId');
       this.categoryId = +params.get('categoryId');
       this.postId = +params.get('postId');
       this.content = params.get('content');
       
       if (this.categoryId) {
         this.service.searchCategoryId = this.categoryId;
       }
     });
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getPosts() {
    this.service.getLatestPosts()
      .subscribe(data => {
        this.posts = data;
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

  loadMore() {
    if (this.posts && this.posts.length > 0) {
      let lastPostId = this.posts[this.posts.length - 1].id;
      let criteria = { ...this.service.searchCriteria, fromPostId: lastPostId};
    
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

  urlFriendly(str) {
    var url = str.substr(0, 200);
    return this.service.removeAccents(url).replace(/[^a-zA-Z0-9]/g, '-').replace(/--+/g, '-');
  }

  onCategoryReset() {
    this.service.searchCategoryId = null;
  }
}

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
})
export class PostListComponent implements OnInit, OnDestroy{
  

  public posts: Post[];
  public errorMessage;
  public successMessage;
  public searchCity: number;
  public searchCategory: number;
  public searchContent: string;
  private subscription: Subscription;

  constructor(private service: PostService, private route: ActivatedRoute) { }
  ngOnInit() {
    // this.route.paramMap.subscribe(params => {
    //   this.searchCity = +params.get('city');
    //   this.searchCategory = +params.get('category');
    //   this.searchContent = params.get('content');

    //   if (this.searchCity || this.searchCategory || this.searchContent) {
    //     const criteria: PostSearchCriteria = {
    //       fromPostId: 0,
    //       titleContain: this.searchContent,
    //       cityId: this.searchCity,
    //       categoryId: this.searchCategory,
    //     };

    //     this.searchPosts(criteria);
    //   }
    //   else this.getPosts();


    // });

    this.subscription = this.service.notifyObservable$.subscribe((criteria: PostSearchCriteria) => {
      if(!criteria) this.getPosts();
      else this.searchPosts(criteria);
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
}

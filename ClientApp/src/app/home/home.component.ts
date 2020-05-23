import { Component, OnInit } from '@angular/core';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';
import { PostSearchCriteria } from '../models/postSearchCriteria';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{

  public posts: Post[];
  public errorMessage;
  public successMessage;

  constructor(private service: PostService) { }
  ngOnInit() {
    if (this.service.searchCriteria && (this.service.searchCriteria.titleContain || this.service.searchCriteria.city)) {
      this.searchPosts();
    }
    else this.getPosts();
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

  searchPosts() {
    this.service.searchLatest(this.service.searchCriteria)
      .subscribe(data => {
        this.posts = data;
        this.successMessage = `(${this.posts.length} items)`;
        this.service.searchCriteria = null;
      }, error => {
        this.errorMessage = error;
      }
      );
  }
}

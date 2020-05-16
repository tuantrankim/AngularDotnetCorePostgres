import { Component, OnInit } from '@angular/core';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';

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
    this.getPosts();
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
}

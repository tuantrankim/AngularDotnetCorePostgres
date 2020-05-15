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
    // console.log(request);
    this.service.get("posts")
      .subscribe(data => {
        this.posts = data as Post[];
        this.successMessage = JSON.stringify(data);
      }, error => {
        this.errorMessage = JSON.stringify(error);
      }
      );
  }
}

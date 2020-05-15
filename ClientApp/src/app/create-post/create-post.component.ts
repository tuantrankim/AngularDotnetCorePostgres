import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { Post } from '../models/Post';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})

export class CreatePostComponent implements OnInit {
  public newPost: Post = new Post();
  public errorMessage;
  public successMessage;
  constructor(private service: PostService) { }

  ngOnInit() {
  }

  submit(f) {
    console.log(this.newPost);
    console.log(f);
    this.createPost();
  }

  createPost() {
    // console.log(request);
    this.service.post("posts",this.newPost)
    .subscribe(data => {
      this.successMessage = JSON.stringify(data);
    }, error => {
      this.errorMessage = JSON.stringify(error);
    }
    );
  }
}



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
  private myForm;

  constructor(private service: PostService) { }

  ngOnInit() {
  }

  submit(f) {
    let p = { ...this.newPost };
    this.myForm = f;
    this.createPost(p);
  }

  createPost(p) {
    // console.log(request);
    this.service.addNewPost(p)
    .subscribe(data => {
      this.successMessage = JSON.stringify(data);
      this.myForm.resetForm();
    }, error => {
      this.errorMessage = JSON.stringify(error);
    }
    );
  }
}



import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {
  public newPost: Post = new Post();
  constructor() { }

  ngOnInit() {
    this.newPost.Content = "";
    this.newPost.ContactEmail = "";
    this.newPost.ContactPhone = "";
  }

  submit(f) {
    console.log(this.newPost);
    console.log(f);
  }
}

class Post {
  Content: string;
  ContactEmail: string;
  ContactPhone: string;
}

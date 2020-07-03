import { Component, OnInit } from '@angular/core';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { PostService } from '../services/post.service';
import { Router, ActivatedRoute } from '@angular/router';
import { City } from '../models/City';
import { Category } from '../models/Category';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
    ngOnInit(): void {
      window.addEventListener('scroll', this.scrolling, true);
    }
  isExpanded = false;
  public showTopIcon = false;
  constructor(private service: PostService, private router: Router, private route: ActivatedRoute) { }

  scrolling = (s) => {
    let sc = s.target.scrollingElement.scrollTop;
    console.log();
    if (sc >= 100) { this.showTopIcon = true }
    else { this.showTopIcon = false }
  }
  gotoTop() {
    window.scroll({
      top: 0,
      left: 0,
      behavior: 'smooth'
    });
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

import { Component } from '@angular/core';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { PostService } from '../services/post.service';
import { Router } from '@angular/router';
import { City } from '../models/City';
import { Category } from '../models/Category';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public searchCriteria = new PostSearchCriteria();

  constructor(private service: PostService, private router: Router) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  searchPosts() {
    this.service.searchCriteria.titleContain = this.searchCriteria.titleContain;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigateByUrl('/');
    //window.location.href = "https://localhost:44385/";
  }
  onCityChange(city: City) {
    console.log("on city changed");
    console.log(city);
  }
  onCategoryChange(category: Category) {
    console.log("on category changed");
    console.log(category);
  }
}

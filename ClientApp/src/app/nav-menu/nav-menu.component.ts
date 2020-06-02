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
  //public searchCriteria = new PostSearchCriteria();
  public searchContent = "";
  public showTopIcon = false;
  constructor(private service: PostService, private router: Router, private route: ActivatedRoute) { }

  scrolling = (s) => {
    let sc = s.target.scrollingElement.scrollTop;
    console.log();
    if (sc >= 500) { this.showTopIcon = true }
    else { this.showTopIcon = false }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  searchPosts() {
    console.log("on search content");
    this.service.searchTitleContain = this.searchContent;
  }
  //searchPosts2() {
  //  this.service.searchCriteria.titleContain = this.searchContent;
  //  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  //  this.router.onSameUrlNavigation = 'reload';
  //  this.router.navigateByUrl('/');
  //  //window.location.href = "https://localhost:44385/";
  //}
  onCityChange(city: City) {
    console.log("on city changed");
    console.log(city);

    this.service.searchCityId = city? city.id : null;
    //this.router.navigate(['/search'], { queryParams: { city: city.id } });
    //this.router.navigate(['cityId', city.id], { relativeTo: this.route });
    //this.router.navigate(['/search', city.id]);
  }
  onCategoryChange(category: Category) {
    this.service.searchCategoryId = category? category.id: null;
    console.log("on category changed");
    console.log(category);
    //this.router.navigate(['/search'], { queryParams: { category: category.id } });
  }
}

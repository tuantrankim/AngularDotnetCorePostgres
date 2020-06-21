import { Component, OnInit } from '@angular/core';
import { Category } from '../models/Category';
import { City } from '../models/City';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  public searchContent = "";
  public isExpand = false;
  constructor(private service: PostService) { }

  ngOnInit() {
  }

  searchPosts() {
    console.log("on search content");
    this.service.searchTitleContain = this.searchContent;
  }

  onCityChange(city: City) {
    console.log("on city changed");
    console.log(city);
    this.service.searchCityId = city ? city.id : null;

  }

  onCategoryChange(category: Category) {
    this.service.searchCategoryId = category ? category.id : null;
    console.log("on category changed");
    console.log(category);
    //this.router.navigate(['/search'], { queryParams: { category: category.id } });
  }

  onExpand() {
    this.isExpand = !this.isExpand;
  }
}

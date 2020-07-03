import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Category } from '../models/Category';
import { City } from '../models/City';
import { PostService } from '../services/post.service';
import { Router } from '@angular/router';
import { PostSearchCriteria } from '../models/postSearchCriteria';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  @Output() criteriaChange: EventEmitter<PostSearchCriteria> = new EventEmitter<PostSearchCriteria>();
  private criteria: PostSearchCriteria = { categoryId: null, cityId: null, fromPostId: null, titleContain: null };
  public searchContent = "";
  public isExpand = false;
  constructor(private service: PostService, private router: Router) { }

  ngOnInit() {
  }

  searchPosts() {
    console.log("on search content");
    //this.service.searchTitleContain = this.searchContent;
    this.criteriaChange.emit({ ...this.criteria, titleContain: this.searchContent });
  }

  onCityChange(city: City) {
    console.log("on city changed");
    console.log(city);
    //this.service.searchCityId = city ? city.id : null;
    this.criteria.cityId = city ? city.id : null;
    this.criteriaChange.emit({ ...this.criteria });
  }

  onCategoryChange(category: Category) {
    //this.service.searchCategoryId = category ? category.id : null;
    console.log("on category changed");
    console.log(category);
    
    //this.router.navigate(['/category'], { queryParams: { categoryId: category.id, categoryDescription: category.name } });
    if (!category || !category.id) {
      this.router.navigate(['/']);
    }
    else {
      const categoryDescription = this.service.urlFriendly(category.name);
      this.router.navigate(['/category', category.id, categoryDescription]);
    }
  }

  onExpand() {
    this.isExpand = !this.isExpand;
  }
}

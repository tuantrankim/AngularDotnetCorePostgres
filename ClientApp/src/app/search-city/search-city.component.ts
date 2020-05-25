import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { City } from '../models/City';
import { Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-search-city',
  templateUrl: './search-city.component.html',
  styleUrls: ['./search-city.component.css']
})
export class SearchCityComponent implements OnInit {

  constructor(private service: PostService) {
  }
  cities: City[];
  successMessage: string = "";
  errorMessage: string = "";
  public model: City = new City();

  ngOnInit() {
    //this.getCities();
  }
  formatter = (city: City) => city.name;

  search = (text$: Observable<string>) => text$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    filter(term => term.length >= 2),
    map(term => this.cities
      .filter(
        (state) => {
          let tokens = term.split(' ');
          let regexStr = "";
          tokens.forEach(t => regexStr += `(?=.*${t.trim()})`);
          
          return new RegExp(regexStr, 'mi') //multiline, case insensitive
            .test(state.name)
        }
    ).slice(0, 20))
  );

  public getCities() {
    if (this.cities) return;

    this.service.getAllCities()
      .subscribe(data => {
        this.cities = data;
        this.successMessage = `(${this.cities.length} items)`;
      }, error => {
        this.errorMessage = error;
      }
      );
  }

  selectedItem(item) {
    this.service.searchCriteria.cityId = item.item.id;
    //console.log(item.item);
  }
}

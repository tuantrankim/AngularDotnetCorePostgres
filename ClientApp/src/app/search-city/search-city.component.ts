import { Component, OnInit, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from '../services/post.service';
import { City } from '../models/City';
import { Observable, Subject, merge } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, map } from 'rxjs/operators';
import { NgbTypeahead } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-search-city',
  templateUrl: './search-city.component.html',
  styleUrls: ['./search-city.component.css']
})
export class SearchCityComponent implements OnInit {
  @Input() globalSearch: boolean;
  @Output() cityChange: EventEmitter<City> = new EventEmitter<City>();

  constructor(private service: PostService) {
  }
  cities: City[];
  successMessage: string = "";
  errorMessage: string = "";
  public model: City = new City();


  ngOnInit() {
    this.getCities();
  }
  inputFormatter = (city: City) => city.name;
  resultFormatter = (city: City) => city.name;

  //resultFormatter(value: any) {
  //  return value.name;
  //}

  //inputFormatter(city: any)   {
  //  if (city.name)
  //    return city.name
  //  return city;
  //}

  @ViewChild('instance', { static: true }) instance: NgbTypeahead;
  focus$ = new Subject<string>();
  click$ = new Subject<string>();

  search = (text$: Observable<string>) => {
    const debouncedText$ = text$.pipe(debounceTime(200), distinctUntilChanged());
    const clicksWithClosedPopup$ = this.click$.pipe(filter(() => !this.instance.isPopupOpen()));
    const inputFocus$ = this.focus$;

    return merge(debouncedText$, inputFocus$, clicksWithClosedPopup$).pipe(
      map(term => {
        this.getCities();
        return (term === '' ? this.cities
          //: this.cities.filter(v => v.toLowerCase().indexOf(term.toLowerCase()) > -1)).slice(0, 10))
          : this.cities.filter(
            (city) => {
              let tokens = term.split(' ');
              let regexStr = "";
              tokens.forEach(t => regexStr += `(?=.*${t.trim()})`);

              return new RegExp(regexStr, 'mi') //multiline, case insensitive
                .test(city.name)
            }
          )
        ).slice(0, 20);
        })
    );
  }

  search2 = (text$: Observable<string>) => text$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    //filter(term => term.length >= 2),
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
        this.cities = [...data];
        this.successMessage = `(${this.cities.length} items)`;
        this.service.setAllCities(data);
        this.cities.unshift({ id: null, name: "---  Tất cả  ---" });
      }, error => {
        this.errorMessage = error;
      }
      );
  }

  selectedItem(item) {
    //if (this.globalSearch) this.service.searchCriteria.cityId = item.item.id;
    console.log("Search item selected");
    this.cityChange.emit(item.item);
  }
  onSearch(tooltip) {
    if (!this.model) {
      this.model = null;
      //this.service.searchCriteria.cityId = null;
      tooltip.open();

    }
    else {
      if (!this.model.id) {
        this.model = null;
      }
      tooltip.close();
    }
    console.log("Search button click");
    this.cityChange.emit(this.model);
  }

  searchBtnClick(tooltip) {
    if (!this.model) {
      this.model = null;
      //this.service.searchCriteria.cityId = null;
      tooltip.open();

    }
    else {
      if (!this.model.id) {
        this.model = null;
      }
      tooltip.close();
    }
      console.log("Search button click");
    this.cityChange.emit(this.model);
    
  }

  showPopOver = () => { return !this.model || !this.model.id };
  tooltipContent = (term) => term ? term + " không tồn tại. Bộ lọc được xóa" : "Bộ lọc được xóa";
}

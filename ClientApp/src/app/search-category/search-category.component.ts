import { Component, OnInit, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from '../services/post.service';
import { Category } from '../models/Category';
import { Observable, Subject, merge } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, map } from 'rxjs/operators';
import { NgbTypeahead } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-search-category',
  templateUrl: './search-category.component.html',
  styleUrls: ['./search-category.component.css']
})
export class SearchCategoryComponent implements OnInit {
  @Input() globalSearch: boolean;
  @Output() categoryChange: EventEmitter<Category> = new EventEmitter<Category>();

  constructor(private service: PostService) {
  }
  categories: Category[];
  successMessage: string = "";
  errorMessage: string = "";
  public model: Category = new Category();


  ngOnInit() {
    this.getCategories();
  }
  inputFormatter = (category: Category) => category.name;
  resultFormatter = (category: Category) => category.name;

  //resultFormatter(value: any) {
  //  return value.name;
  //}

  //inputFormatter(category: any)   {
  //  if (category.name)
  //    return category.name
  //  return category;
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
        this.getCategories();
        return (term === '' ? this.categories
          //: this.cities.filter(v => v.toLowerCase().indexOf(term.toLowerCase()) > -1)).slice(0, 10))
          : this.categories.filter(
            (category) => {
              let tokens = this.service.removeAccents(term).split(' ');
              let regexStr = "";
              tokens.forEach(t => regexStr += `(?=.*${t.trim()})`);

              return new RegExp(regexStr, 'mi') //multiline, case insensitive
                .test(this.service.removeAccents(category.name))
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
    map(term => this.categories
      .filter(
        (category) => {
          let tokens = this.service.removeAccents(term).split(' ');
          let regexStr = "";
          tokens.forEach(t => regexStr += `(?=.*${t.trim()})`);
          
          return new RegExp(regexStr, 'mi') //multiline, case insensitive
            .test(this.service.removeAccents(category.name))
        }
    ).slice(0, 20))
  );

  public getCategories() {
    if (this.categories) return;

    this.service.getAllCategories()
      .subscribe(data => {
        this.categories = [...data];
        this.categories.unshift({ id: null, name: "---  Tất cả  ---", categoryGroupId: null, categoryGroupName: null });
        this.successMessage = `(${this.categories.length} items)`;
      }, error => {
        this.errorMessage = error;
      }
      );
  }

  selectedItem(item) {
    //if (this.globalSearch) this.service.searchCriteria.categoryId = item.item.id;
    console.log("Search item selected");
    this.categoryChange.emit(item.item);
  }

  onSearch(tooltip) {
    if (!this.model) {
      this.model = null;
      //this.service.searchCriteria.categoryId = null;
      tooltip.open();

    }

    else {
      if (!this.model.id) {
        this.model = null;
      }

      tooltip.close();
    }
    console.log("Search button click");
    this.categoryChange.emit(this.model);
  }

  searchBtnClick(tooltip) {
    if (!this.model) {
      this.model = null;
      //this.service.searchCriteria.categoryId = null;
      tooltip.open();
      
    }
    
    else {
      if (!this.model.id) {
        this.model = null;
      }

      tooltip.close();
    }
    console.log("Search button click");
    this.categoryChange.emit(this.model);
    
  }

  showPopOver = () => { return !this.model || !this.model.id };
  tooltipContent = (term) => term ? term + " không tồn tại. Bộ lọc được xóa" : "Bộ lọc được xóa";
}

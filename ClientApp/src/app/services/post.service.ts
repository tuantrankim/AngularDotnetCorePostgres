import { Injectable } from '@angular/core';
import { Observable, throwError, BehaviorSubject, of } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Post } from '../models/Post';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { City } from '../models/City';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private baseUrl = '';
  private postUrl = '';
  private cityUrl = '';
  private categoryUrl = '';
  private notify = new BehaviorSubject<any>(null);
  public notifyObservable$ = this.notify.asObservable();
  //private searchCriteria: PostSearchCriteria;

  private _searchFromPostId: number;
  private _searchTitleContain: string;
  private _searchCityId: number;
  private _searchCategoryId: number;

  private _cities: City[];
  private _categories: Category[];

  constructor(private http: HttpClient) {
    if (environment.baseUrl) this.baseUrl = environment.baseUrl;
    else this.baseUrl = window.location.origin + '/api/';

    this.postUrl = this.baseUrl + 'posts/';
    this.cityUrl = this.baseUrl + 'cities/';
    this.categoryUrl = this.baseUrl + 'categories/';

  }

  public get searchFromPostId()
  {
    if (!this._searchFromPostId) {
      this._searchFromPostId = JSON.parse(localStorage.getItem("searchFromPostId"));
    }
    return this._searchFromPostId;
  }

  public set searchFromPostId(value: number) {
    if (value !== this._searchFromPostId) {
      this._searchFromPostId = value;
      localStorage.setItem("searchFromPostId", JSON.stringify(value));
      this.notify.next(this.searchCriteria);
    }
  }

  public get searchCityId() {
    if (!this._searchCityId) {
      this._searchCityId = JSON.parse(localStorage.getItem("searchCityId"));
    }
    return this._searchCityId;
  }

  public set searchCityId(value: number) {
    if (value !== this._searchCityId) {
      this._searchCityId = value;
      localStorage.setItem("searchCityId", JSON.stringify(value));
      this.notify.next(this.searchCriteria);
    }
  }

  public get searchCategoryId() {
    if (!this._searchCategoryId) {
      this._searchCategoryId = JSON.parse(localStorage.getItem("searchCategoryId"));
    }
    return this._searchCategoryId;
  }

  public set searchCategoryId(value: number) {
    if (value !== this._searchCategoryId) {
      this._searchCategoryId = value;
      localStorage.setItem("searchCategoryId", JSON.stringify(value));
      this.notify.next(this.searchCriteria);
    }
  }

  public get searchTitleContain() {
    if (!this._searchTitleContain) {
      this._searchTitleContain = JSON.parse(localStorage.getItem("searchTitleContain"));
    }
    return this._searchTitleContain;
  }

  public set searchTitleContain(value: string) {
    if (value !== this._searchTitleContain) {
      this._searchTitleContain = value;
      localStorage.setItem("searchTitleContain", JSON.stringify(value));
      this.notify.next(this.searchCriteria);
    }
  }

  //public get searchContent()
  //{
  //  return this.searchCriteria.titleContain;
  //}
  //public set searchContent(content: string)
  //{
  //  if(this.searchContent !== content)    
  //  {
  //    this._searchCriteria.titleContain = content;
  //    localStorage["SearchCriteria"] = JSON.stringify(this._searchCriteria);
  //    this.notify.next(this._searchCriteria);
  //  }
  //}

  //public get searchCityId()
  //{
  //  return this.searchCriteria.cityId;
  //}
  //public set searchCityId(cityId: number)
  //{
  //  if(this.searchCityId !== cityId)    
  //  {
  //    this._searchCriteria.cityId = cityId;
  //    localStorage["SearchCriteria"] = JSON.stringify(this._searchCriteria);
  //    this.notify.next(this._searchCriteria);
  //  }
  //}

  //public get searchCategoryId()
  //{
  //  return this.searchCriteria?.categoryId;
  //}
  //public set searchCategoryId(categoryId: number)
  //{
  //  if(this.searchCategoryId !== categoryId)    
  //  {
  //    this._searchCriteria.categoryId = categoryId;
  //    localStorage["SearchCriteria"] = JSON.stringify(this._searchCriteria);
  //    this.notify.next(this._searchCriteria);
  //  }
  //}

  //public set searchCriteria(criteria: PostSearchCriteria) {
  //  if (!criteria) localStorage.removeItem("SearchCriteria");

  //  if(JSON.stringify(this._searchCriteria) !== JSON.stringify(criteria)) {
  //    this._searchCriteria = {...criteria};
  //    localStorage["SearchCriteria"] = JSON.stringify(this._searchCriteria);
  //    this.notify.next(criteria);
  //  }
  //}

  public get searchCriteria(): PostSearchCriteria{
    return {
      fromPostId :  this._searchFromPostId,
      titleContain : this._searchTitleContain,
      cityId : this._searchCityId,
      categoryId : this._searchCategoryId
    }
  }

  searchLatest(postSearchCriteria: PostSearchCriteria): Observable<Post[]> {
    return this.http.post<Post[]>(this.postUrl + 'searchLatest', postSearchCriteria)
      .pipe(catchError(this.handleError));
  }

  getLatestPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.postUrl + 'getLatest',)
      .pipe(catchError(this.handleError));
  }

  addNewPost(newPost: Post) {
    return this.http.post<Post>(this.postUrl + 'addnew', newPost)
      .pipe(catchError(this.handleError));
  }
  setAllCities(value: City[]) {
    if (value !== this._cities) {
      this._cities = value;
      localStorage.setItem("cities", JSON.stringify(value));
    }
  }

  getAllCities(): Observable<City[]> {
    if (!this._cities) {
      let items: City[];
      try {
        items = JSON.parse(localStorage.getItem("cities"));
      }
      catch
      {
        localStorage.removeItem("cities");
      }

      if (!items || items.length == 0) {
        return this.http.get<City[]>(this.cityUrl + 'all')
          .pipe(catchError(this.handleError));
      }
      else this._cities = items;
    }

    return of(this._cities);
  }

  getAllCategories(): Observable<Category[]> {
    if (!this._categories) {
      let items: Category[];
      try {
        items = JSON.parse(localStorage.getItem("categories"));
      }
      catch
      {
        localStorage.removeItem("categories");
      }

      if (!items || items.length == 0) {
        return this.http.get<Category[]>(this.categoryUrl + 'all')
          .pipe(catchError(this.handleError));
      }
      else this._categories = items;
    }

    return of(this._categories);
  }
  setAllCategories(value: Category[]) {
    if (value !== this._categories) {
      this._categories = value;
      localStorage.setItem("categories", JSON.stringify(value));
    }
  }
  removeAccents(str) {
    var AccentsMap = [
      "aàảãáạăằẳẵắặâầẩẫấậ",
      "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
      "dđ", "DĐ",
      "eèẻẽéẹêềểễếệ",
      "EÈẺẼÉẸÊỀỂỄẾỆ",
      "iìỉĩíị",
      "IÌỈĨÍỊ",
      "oòỏõóọôồổỗốộơờởỡớợ",
      "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
      "uùủũúụưừửữứự",
      "UÙỦŨÚỤƯỪỬỮỨỰ",
      "yỳỷỹýỵ",
      "YỲỶỸÝỴ"
    ];
    for (var i = 0; i < AccentsMap.length; i++) {
      var re = new RegExp('[' + AccentsMap[i].substr(1) + ']', 'g');
      var char = AccentsMap[i][0];
      str = str.replace(re, char);
    }
  return str;
}
  /////////////////////////////////////////////////////////
  update(action: string, resource) {
    return this.http.patch(this.postUrl + '/' + action + '/' + resource.id, { isRead: true })
      .pipe(catchError(this.handleError));
  }

  delete(action: string, id) {
    return this.http.delete(this.postUrl + '/' + action + '/' + id)
        .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
        // A client-side or network error occurred. Handle it accordingly.
        console.log('An error occurred:', error.error.message);
    } else {

      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.log(
        `Backend error: code ${error.status}, ${error.error.error}, ${error.error.error_description}`, error);
      // Known error
      if (error.status === 404) {
          return throwError('Not found');
        }
      if (error.status === 400) {
        return throwError('Bad request');
      }
    }
     // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }
}


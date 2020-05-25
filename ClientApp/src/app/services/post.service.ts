import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Post } from '../models/Post';
import { PostSearchCriteria } from '../models/postSearchCriteria';
import { City } from '../models/City';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private baseUrl = '';
  private postUrl = '';
  private cityUrl = '';

  public searchCriteria: PostSearchCriteria;

  constructor(private http: HttpClient) {
    if (environment.baseUrl) this.baseUrl = environment.baseUrl;
    else this.baseUrl = window.location.origin + '/api/';

    this.postUrl = this.baseUrl + 'posts/';
    this.cityUrl = this.baseUrl + 'cities/';

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

  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.cityUrl + 'all')
      .pipe(catchError(this.handleError));
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


import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private baseUrl = '';

  constructor(private http: HttpClient) {
    if (environment.baseUrl) this.baseUrl = environment.baseUrl;
    else this.baseUrl = window.location.origin + '/api';
  }

  get(action: string) {
    return this.http.get(this.baseUrl + '/' + action)
      .pipe(catchError(this.handleError));
  }

  post(action: string, resource) {
    return this.http.post(this.baseUrl + '/' + action, resource)
      .pipe(catchError(this.handleError));
  }

  update(action: string, resource) {
    return this.http.patch(this.baseUrl + '/' + action + '/' + resource.id, { isRead: true })
      .pipe(catchError(this.handleError));
  }

  delete(action: string, id) {
    return this.http.delete(this.baseUrl + '/' + action + '/' + id)
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


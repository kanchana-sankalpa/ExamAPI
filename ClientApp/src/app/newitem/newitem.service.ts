import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import {  Newitem } from './newitem';
   

@Injectable({
  providedIn: 'root'
})
export class NewitemService {

  private apiURL = "https://localhost:44303/api";


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }
   
  getAll(): Observable<Newitem[]> {
    console.log('getAll service')
    return this.httpClient.get<Newitem[]>(this.apiURL + '/NewItems')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  create(newiem): Observable<Newitem> {
    return this.httpClient.post<Newitem>(this.apiURL + '/NewItems', JSON.stringify(newiem), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  } 

  errorHandler(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }
}

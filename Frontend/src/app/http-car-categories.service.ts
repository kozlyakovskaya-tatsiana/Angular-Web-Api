import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpCarCategoriesService {
  private url = 'https://localhost:44337//api/carcategories/';
  constructor(private http: HttpClient) { }
  public getCarCategories(): Observable<any>{
    return this.http.get(this.url);
  }
}

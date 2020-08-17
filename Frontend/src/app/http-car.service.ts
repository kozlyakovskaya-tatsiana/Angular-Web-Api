import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Car} from './add-car/add-car.component';

@Injectable({
  providedIn: 'root'
})
export class HttpCarService {
  private url = 'https://localhost:44337//api/cars/';
  constructor(private http: HttpClient) { }
  public createCar(car: Car): any{
    return this.http.post(this.url, car);
  }
  public getCars(carCategory: string): any{
    return this.http.get(this.url + carCategory);
 }
}

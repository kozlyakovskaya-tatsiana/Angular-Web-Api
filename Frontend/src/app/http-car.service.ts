import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

export class Car {
  public Id: number;
  public Name: string;
  public Year: number;
  public Color: string;
  public Carcase: string;
  public MaxPassengersAmount: number;
  public CostRentForDay: number;
  public ImgSrc: string | ArrayBuffer;
  public CategoryName: string;
}
@Injectable({
  providedIn: 'root'
})
export class HttpCarService {
  private url = 'https://localhost:44337//api/cars/';
  constructor(private http: HttpClient) { }
  public createCar(car: Car): Observable<any>{
    return this.http.post(this.url, car);
  }
  public getCars(carCategory: string): Observable<any>{
    return this.http.get(this.url + carCategory);
 }
 public getCar(id: number): Observable<any>{
    return this.http.get(this.url + id);
 }
 public editCar(car: Car): Observable<any>{
    return  this.http.put(this.url, car);
 }
}

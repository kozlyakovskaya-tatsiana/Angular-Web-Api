import { Component, OnInit } from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';


@Component({
  selector: 'app-autopark',
  templateUrl: './autopark.component.html',
  styleUrls: ['./autopark.component.css']
})
export class AutoparkComponent implements OnInit {

  constructor(private httpCar: HttpCarService) { }
  cars: Car[];

  ngOnInit(): void {
    this.httpCar.getCars('').subscribe(
      data => this.cars = data
    );
  }

}

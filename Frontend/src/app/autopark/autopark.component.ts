import { Component, OnInit } from '@angular/core';
import {HttpCarService} from '../http-car.service';
import {Car} from '../add-car/add-car.component';

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

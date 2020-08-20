import { Component, OnInit } from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';
import swal from 'sweetalert';


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
      data => this.cars = data,
      err => {
        console.log(err);
        const errMessage: string = err.error instanceof Error ? err.error.message : err.error;
        swal({
            text: errMessage,
            icon: 'error'
          });
      }
    );
  }
}

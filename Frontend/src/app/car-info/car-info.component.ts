import { Component, OnInit } from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';
import {Subscription} from 'rxjs';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-car-info',
  templateUrl: './car-info.component.html',
  styleUrls: ['./car-info.component.css']
})
export class CarInfoComponent implements OnInit {

  constructor(private httpCar: HttpCarService,
              private route: ActivatedRoute) {
    this.routeSubscription = this.route.params.subscribe(params => {
      this.id = params.id;
      this.ngOnInit();
    });
  }
  private routeSubscription: Subscription;
  car: Car;
  id: number;
  ngOnInit(): void {
    this.httpCar.getCar(this.id).subscribe(
      data => this.car = data,
      error => alert(error.Message)
    );
  }

}

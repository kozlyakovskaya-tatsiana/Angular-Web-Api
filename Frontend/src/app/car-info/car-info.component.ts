import { Component, OnInit } from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';
import {Subscription} from 'rxjs';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import swal from 'sweetalert';

@Component({
  selector: 'app-car-info',
  templateUrl: './car-info.component.html',
  styleUrls: ['./car-info.component.css']
})
export class CarInfoComponent implements OnInit {

  constructor(private httpCar: HttpCarService,
              private route: ActivatedRoute,
              private location: Location) {
    this.showEditComponent = false;
    this.routeSubscription = this.route.params.subscribe(params => {
      this.id = params.id;
      this.ngOnInit();
    });
  }
  private routeSubscription: Subscription;
  car: Car;
  id: number;
  showEditComponent: boolean;
  ngOnInit(): void {
    this.httpCar.getCar(this.id).subscribe(
      data => this.car = data,
      error => swal({
        text: error.Message,
        icon: 'error'
      })
    );
  }
  deleteCar(event): void{
    swal({
      text: 'Do you really want to delete?',
      icon: 'warning',
      buttons: ['Cancel', 'Delete'],
      dangerMode: true
    }).then(value => {
      if (value){
        event.target.disabled = true;
        this.showEditComponent = false;
        this.httpCar.deleteCar(this.car.Id).subscribe(
          res => {
            event.target.disabled = false;
            swal({
              text: 'Deleting is successful',
              icon: 'success'
            });
            this.location.back();
          },
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
    });
  }
}

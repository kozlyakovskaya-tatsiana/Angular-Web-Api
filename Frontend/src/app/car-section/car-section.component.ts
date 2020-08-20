import {Component, Input, OnInit} from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';
import swal from 'sweetalert';


@Component({
  selector: 'app-car-section',
  templateUrl: './car-section.component.html',
  styleUrls: ['./car-section.component.css']
})
export class CarSectionComponent implements OnInit {
  @Input() sectionName: string;
  cars: Car[];
  @Input() category: string;

  constructor(private httpCar: HttpCarService) { }

  ngOnInit(): void {
    this.httpCar.getCars(this.category).subscribe(
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

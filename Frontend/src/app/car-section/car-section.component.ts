import {Component, Input, OnInit} from '@angular/core';
import {Car, HttpCarService} from '../http-car.service';


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
      error => alert(error.Message)
    );
  }

}

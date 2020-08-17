import { Component, OnInit } from '@angular/core';
import {Car} from '../add-car/add-car.component';
/*import {CarViewModel} from '../car-card/car-card.component';*/

export class CarCategory {
  constructor(public text: string, public imgSrc: string) {
  }
}

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})

export class MainComponent implements OnInit {

  constructor() {
    this.car = new Car();
    this.car.Name = 'Audi X540SA';
    this.car.ImgSrc = 'assets/bmw1.jpg';
    this.car.Year = 2017;
    this.car.CostRentForDay = 17.89;
    this.cars = [this.car, this.car, this.car, this.car];
  }

  carCategories: CarCategory[] = [
    new CarCategory('Economy class', 'assets/ekonom.jpg'),
    new CarCategory('Middle class', 'assets/middle.jpg'),
    new CarCategory('Business class', 'assets/businessclass.jpg'),
    new CarCategory('Minibuses', 'assets/minibus.jpg'),

  ];
  car: Car;
  cars: Car[];

  ngOnInit(): void {
  }

}

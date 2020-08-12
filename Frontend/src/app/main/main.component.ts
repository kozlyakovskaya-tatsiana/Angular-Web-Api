import { Component, OnInit } from '@angular/core';
import {CarViewModel} from '../car-card/car-card.component';

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

  constructor() { }

  carCategories: CarCategory[] = [
    new CarCategory('Economy class', 'assets/ekonom.jpg'),
    new CarCategory('Middle class', 'assets/middle.jpg'),
    new CarCategory('Business class', 'assets/businessclass.jpg'),
    new CarCategory('Minibuses', 'assets/minibus.jpg'),

  ];
  car: CarViewModel = new CarViewModel('Audi X540SA', 'assets/bmw1.jpg', 2017, 17.89);
  cars: CarViewModel[] = [this.car, this.car, this.car, this.car];

  ngOnInit(): void {
  }

}

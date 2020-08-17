import {Component, Input, OnInit} from '@angular/core';
import {Car} from '../add-car/add-car.component';

/*export class CarViewModel {
  constructor(public carName: string,
              public carImgSrc: string,
              public carYear: number,
              public carCost: number) {
  }

}*/
@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.css']
})
export class CarCardComponent implements OnInit {
  @Input() car: Car;
  constructor() { }

  ngOnInit(): void {
  }

}

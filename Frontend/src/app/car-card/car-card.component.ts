import {Component, Input, OnInit} from '@angular/core';

export class CarViewModel {
  constructor(public carName: string,
              public carImgSrc: string,
              public carYear: number,
              public carCost: number) {
  }

}
@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.css']
})
export class CarCardComponent implements OnInit {
  @Input() carImgSrc: string;
  @Input() carName: string;
  @Input() carYear: number;
  @Input() carCostForDay: number;
  @Input() car: CarViewModel;
  constructor() { }

  ngOnInit(): void {
  }

}

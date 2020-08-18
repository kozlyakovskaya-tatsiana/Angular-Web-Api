import {Component, Input, OnInit} from '@angular/core';
import {Car} from '../http-car.service';

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

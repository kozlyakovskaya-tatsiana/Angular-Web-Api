import {Component, Input, OnInit} from '@angular/core';
import {CarViewModel} from '../car-card/car-card.component';

@Component({
  selector: 'app-car-section',
  templateUrl: './car-section.component.html',
  styleUrls: ['./car-section.component.css']
})
export class CarSectionComponent implements OnInit {
  @Input() sectionName: string;
  @Input() cars: CarViewModel[];

  constructor() { }

  ngOnInit(): void {
  }

}

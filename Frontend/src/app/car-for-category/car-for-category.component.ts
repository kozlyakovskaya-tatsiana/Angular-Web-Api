import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-car-for-category',
  templateUrl: './car-for-category.component.html',
  styleUrls: ['./car-for-category.component.css']
})
export class CarForCategoryComponent implements OnInit {

  @Input() text: string;
  @Input() imgSrc: string;

  constructor() { }

  ngOnInit(): void {
  }

}

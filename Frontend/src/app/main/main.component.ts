import { Component, OnInit } from '@angular/core';
import {HttpCarCategoriesService} from '../http-car-categories.service';
import swal from 'sweetalert';

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

  constructor(private httpCarCategory: HttpCarCategoriesService) {}

  carCategories: CarCategory[] = [
    new CarCategory('Economy class', 'assets/ekonom.jpg'),
    new CarCategory('Middle class', 'assets/middle.jpg'),
    new CarCategory('Business class', 'assets/businessclass.jpg'),
    new CarCategory('Minibuses', 'assets/minibus.jpg')
  ];
  categories: string[];
  ngOnInit(): void {
    this.httpCarCategory.getCarCategories().subscribe(
      data => this.categories = data,
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

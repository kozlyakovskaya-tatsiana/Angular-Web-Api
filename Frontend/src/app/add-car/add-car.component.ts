import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Car, HttpCarService} from '../http-car.service';
import {HttpCarCategoriesService} from '../http-car-categories.service';

export const addForm: FormGroup = new FormGroup({
  carName: new FormControl('', [
    Validators.required,
    Validators.maxLength(50)
  ]),
  carYear: new FormControl('', [
    Validators.required,
    Validators.min(1800)
  ]),
  carColor: new FormControl('', Validators.required),
  carCarcase: new FormControl('', Validators.required),
  carMaxPassengersAmount: new FormControl('', Validators.required),
  carImgSrc: new FormControl('', Validators.required),
  carCategory: new FormControl('', Validators.required),
  carCost: new FormControl('', Validators.required),
});
@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})

export class AddCarComponent implements OnInit {

  constructor( private httpCarCategories: HttpCarCategoriesService,
               private httpCar: HttpCarService) {}
  car: Car = new Car();
  carCategories: string[];
  addForm: FormGroup = addForm;
  ngOnInit(): void {
    this.httpCarCategories.getCarCategories().subscribe(
      data => this.carCategories = data,
      error => {
        console.log(error);
        alert('Error has happend. Try it later.\n' + error.Message);
      }
    );
  }
  loadImage(): void{
    document.getElementById('uploadImgBtn').click();
  }
  onFileChange(event): void{
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = e => {
      this.car.ImgSrc = e.target.result;
    };
    reader.readAsDataURL(file);
  }
  addCar(event): void{
    event.target.disabled = true;
    this.httpCar.createCar(this.car).subscribe(
      res => {
        event.target.disabled = false;
        const inputs = document.getElementsByTagName('input');
        /*Array.from(inputs).forEach(input => input.value = '');
        this.car.CategoryName = '';*/
        alert('Adding is successful');
      },
      error => {
        event.target.disabled = false;
        console.log(error);
        alert('Error has happend.\n' + error.Message);
      }
    );
  }
}

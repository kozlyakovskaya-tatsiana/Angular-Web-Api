import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Car, HttpCarService} from '../http-car.service';
import {HttpCarCategoriesService} from '../http-car-categories.service';
import swal from 'sweetalert';

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
        swal({
          text: 'Error has happend.\n' + error.Message,
          icon: 'error'
        });
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
        swal({
          text: 'Adding is successful',
          icon: 'success'
        });
      },
      err => {
        event.target.disabled = false;
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

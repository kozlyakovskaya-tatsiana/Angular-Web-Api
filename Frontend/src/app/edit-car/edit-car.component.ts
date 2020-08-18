import {Component, Input, OnInit} from '@angular/core';
import {HttpCarCategoriesService} from '../http-car-categories.service';
import {Car, HttpCarService} from '../http-car.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {addForm} from '../add-car/add-car.component';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {

  constructor(private httpCarCategories: HttpCarCategoriesService,
              private httpCar: HttpCarService) {
  }

  @Input() car: Car;
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

  loadImage(): void {
    document.getElementById('uploadImgBtn').click();
  }

  onFileChange(event): void {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = e => {
      this.car.ImgSrc = e.target.result;
    };
    reader.readAsDataURL(file);
  }
  editCar(event): void{
    event.target.disabled = true;
    this.httpCar.editCar(this.car).subscribe(
      res => {
        event.target.disabled = false;
        const inputs = document.getElementsByTagName('input');
        /*Array.from(inputs).forEach(input => input.value = '');
        this.car.CategoryName = '';*/
        alert('Editing is successful');
      },
      error => {
        event.target.disabled = false;
        console.log(error);
        alert('Error has happend.\n' + error.Message);
      }
    );
  }
}

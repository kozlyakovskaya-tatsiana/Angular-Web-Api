import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarForCategoryComponent } from './car-for-category.component';

describe('CarForCategoryComponent', () => {
  let component: CarForCategoryComponent;
  let fixture: ComponentFixture<CarForCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarForCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarForCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

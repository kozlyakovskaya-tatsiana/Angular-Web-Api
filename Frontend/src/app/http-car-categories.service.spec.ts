import { TestBed } from '@angular/core/testing';

import { HttpCarCategoriesService } from './http-car-categories.service';

describe('HttpCarCategoriesService', () => {
  let service: HttpCarCategoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpCarCategoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

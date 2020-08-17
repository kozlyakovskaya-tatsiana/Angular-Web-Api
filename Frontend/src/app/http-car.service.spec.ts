import { TestBed } from '@angular/core/testing';

import { HttpCarService } from './http-car.service';

describe('HttpCarService', () => {
  let service: HttpCarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpCarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

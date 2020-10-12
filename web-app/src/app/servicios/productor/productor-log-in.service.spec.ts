import { TestBed } from '@angular/core/testing';

import { ProductorLogInService } from './productor-log-in.service';

describe('ProductorLogInService', () => {
  let service: ProductorLogInService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductorLogInService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

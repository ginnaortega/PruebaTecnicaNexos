import { TestBed } from '@angular/core/testing';

import { HttpFactoryService } from './http-factory.service';

describe('HttpFactoryService', () => {
  let service: HttpFactoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpFactoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

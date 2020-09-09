import { TestBed } from '@angular/core/testing';

import { NewitemService } from './newitem.service';

describe('NewitemService', () => {
  let service: NewitemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NewitemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

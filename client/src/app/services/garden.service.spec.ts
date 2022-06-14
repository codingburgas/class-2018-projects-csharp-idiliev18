import { TestBed } from '@angular/core/testing';

import { GardenService } from './garden.service';

describe('GardenService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GardenService = TestBed.get(GardenService);
    expect(service).toBeTruthy();
  });
});

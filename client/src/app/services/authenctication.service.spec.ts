import { TestBed } from '@angular/core/testing';

import { AuthencticationService } from './authenctication.service';

describe('AuthencticationService', () => {
  let service: AuthencticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthencticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

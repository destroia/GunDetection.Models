import { TestBed } from '@angular/core/testing';

import { SubUsersService } from './sub-users.service';

describe('SubUsersService', () => {
  let service: SubUsersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubUsersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAccessModalComponent } from './user-access-modal.component';

describe('UserAccessModalComponent', () => {
  let component: UserAccessModalComponent;
  let fixture: ComponentFixture<UserAccessModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAccessModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAccessModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

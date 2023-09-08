import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAlarmComponent } from './user-alarm.component';

describe('UserAlarmComponent', () => {
  let component: UserAlarmComponent;
  let fixture: ComponentFixture<UserAlarmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAlarmComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAlarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarListComponent } from './nav-bar-list.component';

describe('NavBarListComponent', () => {
  let component: NavBarListComponent;
  let fixture: ComponentFixture<NavBarListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavBarListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavBarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityWallComponent } from './security-wall.component';

describe('SecurityWallComponent', () => {
  let component: SecurityWallComponent;
  let fixture: ComponentFixture<SecurityWallComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SecurityWallComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SecurityWallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

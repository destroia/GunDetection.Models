import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCameraComponent } from './update-camera.component';

describe('UpdateCameraComponent', () => {
  let component: UpdateCameraComponent;
  let fixture: ComponentFixture<UpdateCameraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCameraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCameraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

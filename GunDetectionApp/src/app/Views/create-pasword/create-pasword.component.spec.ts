import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePaswordComponent } from './create-pasword.component';

describe('CreatePaswordComponent', () => {
  let component: CreatePaswordComponent;
  let fixture: ComponentFixture<CreatePaswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePaswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePaswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

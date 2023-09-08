import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertsReporteComponent } from './alerts-reporte.component';

describe('AlertsReporteComponent', () => {
  let component: AlertsReporteComponent;
  let fixture: ComponentFixture<AlertsReporteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlertsReporteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlertsReporteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CamerasSettingsComponent } from './cameras-settings.component';

describe('CamerasSettingsComponent', () => {
  let component: CamerasSettingsComponent;
  let fixture: ComponentFixture<CamerasSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CamerasSettingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CamerasSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

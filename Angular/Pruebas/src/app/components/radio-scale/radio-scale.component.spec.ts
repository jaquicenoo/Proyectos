import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RadioScaleComponent } from './radio-scale.component';

describe('RadioScaleComponent', () => {
  let component: RadioScaleComponent;
  let fixture: ComponentFixture<RadioScaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RadioScaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RadioScaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

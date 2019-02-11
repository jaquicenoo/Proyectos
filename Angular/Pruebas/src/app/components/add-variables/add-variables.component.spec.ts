import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVariablesComponent } from './add-variables.component';

describe('AddVariablesComponent', () => {
  let component: AddVariablesComponent;
  let fixture: ComponentFixture<AddVariablesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddVariablesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVariablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajPlanComponent } from './dodaj-plan.component';

describe('DodajPlanComponent', () => {
  let component: DodajPlanComponent;
  let fixture: ComponentFixture<DodajPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

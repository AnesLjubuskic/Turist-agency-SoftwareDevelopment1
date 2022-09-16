import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikaziPlanComponent } from './prikazi-plan.component';

describe('PrikaziPlanComponent', () => {
  let component: PrikaziPlanComponent;
  let fixture: ComponentFixture<PrikaziPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrikaziPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikaziPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

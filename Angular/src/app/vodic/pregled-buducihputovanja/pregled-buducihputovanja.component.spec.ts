import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledBuducihputovanjaComponent } from './pregled-buducihputovanja.component';

describe('PregledBuducihputovanjaComponent', () => {
  let component: PregledBuducihputovanjaComponent;
  let fixture: ComponentFixture<PregledBuducihputovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledBuducihputovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledBuducihputovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

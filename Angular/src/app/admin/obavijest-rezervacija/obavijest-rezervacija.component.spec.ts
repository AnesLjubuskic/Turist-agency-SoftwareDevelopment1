import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObavijestRezervacijaComponent } from './obavijest-rezervacija.component';

describe('ObavijestRezervacijaComponent', () => {
  let component: ObavijestRezervacijaComponent;
  let fixture: ComponentFixture<ObavijestRezervacijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObavijestRezervacijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObavijestRezervacijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

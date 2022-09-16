import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledAplikacijaComponent } from './pregled-aplikacija.component';

describe('PregledAplikacijaComponent', () => {
  let component: PregledAplikacijaComponent;
  let fixture: ComponentFixture<PregledAplikacijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledAplikacijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledAplikacijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

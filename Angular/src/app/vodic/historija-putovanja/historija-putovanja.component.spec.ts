import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorijaPutovanjaComponent } from './historija-putovanja.component';

describe('HistorijaPutovanjaComponent', () => {
  let component: HistorijaPutovanjaComponent;
  let fixture: ComponentFixture<HistorijaPutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistorijaPutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistorijaPutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

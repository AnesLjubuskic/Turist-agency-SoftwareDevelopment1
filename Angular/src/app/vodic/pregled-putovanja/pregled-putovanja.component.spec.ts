import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledPutovanjaComponent } from './pregled-putovanja.component';

describe('PregledPutovanjaComponent', () => {
  let component: PregledPutovanjaComponent;
  let fixture: ComponentFixture<PregledPutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledPutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledPutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

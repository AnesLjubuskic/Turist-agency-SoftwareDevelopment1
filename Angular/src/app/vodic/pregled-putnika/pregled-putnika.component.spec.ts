import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledPutnikaComponent } from './pregled-putnika.component';

describe('PregledPutnikaComponent', () => {
  let component: PregledPutnikaComponent;
  let fixture: ComponentFixture<PregledPutnikaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledPutnikaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledPutnikaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

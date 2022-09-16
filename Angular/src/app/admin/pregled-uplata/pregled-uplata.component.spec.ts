import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledUplataComponent } from './pregled-uplata.component';

describe('PregledUplataComponent', () => {
  let component: PregledUplataComponent;
  let fixture: ComponentFixture<PregledUplataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledUplataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledUplataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

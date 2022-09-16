import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupeComponent } from './grupe.component';

describe('GrupeComponent', () => {
  let component: GrupeComponent;
  let fixture: ComponentFixture<GrupeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

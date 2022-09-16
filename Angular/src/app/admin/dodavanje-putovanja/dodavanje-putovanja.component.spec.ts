import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodavanjePutovanjaComponent } from './dodavanje-putovanja.component';

describe('DodavanjePutovanjaComponent', () => {
  let component: DodavanjePutovanjaComponent;
  let fixture: ComponentFixture<DodavanjePutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodavanjePutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodavanjePutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

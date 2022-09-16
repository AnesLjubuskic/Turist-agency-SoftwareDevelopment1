import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodavanjeVodicaComponent } from './dodavanje-vodica.component';

describe('DodavanjeVodicaComponent', () => {
  let component: DodavanjeVodicaComponent;
  let fixture: ComponentFixture<DodavanjeVodicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodavanjeVodicaComponent ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodavanjeVodicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

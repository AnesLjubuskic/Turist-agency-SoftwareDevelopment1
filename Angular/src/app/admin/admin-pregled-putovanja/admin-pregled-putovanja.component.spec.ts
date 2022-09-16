import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPregledPutovanjaComponent } from './admin-pregled-putovanja.component';

describe('AdminPregledPutovanjaComponent', () => {
  let component: AdminPregledPutovanjaComponent;
  let fixture: ComponentFixture<AdminPregledPutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPregledPutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPregledPutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

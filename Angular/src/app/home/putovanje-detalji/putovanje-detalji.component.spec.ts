import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PutovanjeDetaljiComponent } from './putovanje-detalji.component';

describe('PutovanjeDetaljiComponent', () => {
  let component: PutovanjeDetaljiComponent;
  let fixture: ComponentFixture<PutovanjeDetaljiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PutovanjeDetaljiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PutovanjeDetaljiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

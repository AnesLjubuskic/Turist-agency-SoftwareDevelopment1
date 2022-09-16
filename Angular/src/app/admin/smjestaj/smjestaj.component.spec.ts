import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmjestajComponent } from './smjestaj.component';

describe('SmjestajComponent', () => {
  let component: SmjestajComponent;
  let fixture: ComponentFixture<SmjestajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SmjestajComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SmjestajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

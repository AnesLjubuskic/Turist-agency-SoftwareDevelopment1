import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CvSlikaComponent } from './cv-slika.component';

describe('CvSlikaComponent', () => {
  let component: CvSlikaComponent;
  let fixture: ComponentFixture<CvSlikaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CvSlikaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CvSlikaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

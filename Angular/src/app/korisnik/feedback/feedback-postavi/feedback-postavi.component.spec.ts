import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackPostaviComponent } from './feedback-postavi.component';

describe('FeedbackPostaviComponent', () => {
  let component: FeedbackPostaviComponent;
  let fixture: ComponentFixture<FeedbackPostaviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeedbackPostaviComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackPostaviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

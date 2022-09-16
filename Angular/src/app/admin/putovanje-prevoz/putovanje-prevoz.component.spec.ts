import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PutovanjePrevozComponent } from './putovanje-prevoz.component';

describe('PutovanjePrevozComponent', () => {
  let component: PutovanjePrevozComponent;
  let fixture: ComponentFixture<PutovanjePrevozComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PutovanjePrevozComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PutovanjePrevozComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

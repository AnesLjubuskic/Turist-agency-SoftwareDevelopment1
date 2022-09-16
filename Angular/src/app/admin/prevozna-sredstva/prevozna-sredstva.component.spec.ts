import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrevoznaSredstvaComponent } from './prevozna-sredstva.component';

describe('PrevoznaSredstvaComponent', () => {
  let component: PrevoznaSredstvaComponent;
  let fixture: ComponentFixture<PrevoznaSredstvaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrevoznaSredstvaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrevoznaSredstvaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

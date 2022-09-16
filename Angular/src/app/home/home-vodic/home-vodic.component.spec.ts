import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeVodicComponent } from './home-vodic.component';

describe('HomeVodicComponent', () => {
  let component: HomeVodicComponent;
  let fixture: ComponentFixture<HomeVodicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeVodicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeVodicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuducaPutovanjaComponent } from './buduca-putovanja.component';

describe('BuducaPutovanjaComponent', () => {
  let component: BuducaPutovanjaComponent;
  let fixture: ComponentFixture<BuducaPutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BuducaPutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BuducaPutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

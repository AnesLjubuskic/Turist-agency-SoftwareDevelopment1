import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProslaPutovanjaComponent } from './prosla-putovanja.component';

describe('ProslaPutovanjaComponent', () => {
  let component: ProslaPutovanjaComponent;
  let fixture: ComponentFixture<ProslaPutovanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProslaPutovanjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProslaPutovanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

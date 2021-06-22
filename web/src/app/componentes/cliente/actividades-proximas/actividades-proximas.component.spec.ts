import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActividadesProximasComponent } from './actividades-proximas.component';

describe('ActividadesProximasComponent', () => {
  let component: ActividadesProximasComponent;
  let fixture: ComponentFixture<ActividadesProximasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActividadesProximasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActividadesProximasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaSucursalComponent } from './busqueda-sucursal.component';

describe('BusquedaSucursalComponent', () => {
  let component: BusquedaSucursalComponent;
  let fixture: ComponentFixture<BusquedaSucursalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusquedaSucursalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusquedaSucursalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaTipoClaseComponent } from './busqueda-tipo-clase.component';

describe('BusquedaTipoClaseComponent', () => {
  let component: BusquedaTipoClaseComponent;
  let fixture: ComponentFixture<BusquedaTipoClaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusquedaTipoClaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusquedaTipoClaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

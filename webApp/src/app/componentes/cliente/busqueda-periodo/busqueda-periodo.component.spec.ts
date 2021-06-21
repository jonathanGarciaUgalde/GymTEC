import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaPeriodoComponent } from './busqueda-periodo.component';

describe('BusquedaPeriodoComponent', () => {
  let component: BusquedaPeriodoComponent;
  let fixture: ComponentFixture<BusquedaPeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusquedaPeriodoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusquedaPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

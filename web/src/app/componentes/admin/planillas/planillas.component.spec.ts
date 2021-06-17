import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanillasComponent } from './planillas.component';

describe('PlanillasComponent', () => {
  let component: PlanillasComponent;
  let fixture: ComponentFixture<PlanillasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanillasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanillasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TituloManagementComponent } from './titulo-management.component';

describe('TituloManagementComponent', () => {
  let component: TituloManagementComponent;
  let fixture: ComponentFixture<TituloManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TituloManagementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TituloManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

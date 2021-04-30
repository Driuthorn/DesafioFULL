import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalTituloComponent } from './modal-titulo.component';

describe('ModalTituloComponent', () => {
  let component: ModalTituloComponent;
  let fixture: ComponentFixture<ModalTituloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalTituloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalTituloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

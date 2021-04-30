import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { DataTransferService } from 'src/app/core/data-transfer.service';
import { TituloManagementService } from './titulo-management.service';
import { Titulo } from '../../interfaces/titulo.interface';
import { ToastMessageComponent } from 'src/app/components/elements/toast-message/toast-message.component';
import { ModalService } from 'src/app/service/modal.service';
import { ModalTituloComponent } from 'src/app/components/elements/modals/modal-titulo/modal-titulo.component';

@Component({
  selector: 'app-titulo-management',
  templateUrl: './titulo-management.component.html',
  styleUrls: ['./titulo-management.component.css'],
  })
export class TituloManagementComponent implements OnInit {

  titulosList: Titulo[] = [];
  filterArgs: string;

  @ViewChild('toastRef') toastReference: TemplateRef<ToastMessageComponent>;

  constructor(
    private tituloManagementService: TituloManagementService,
    private dataTransferService: DataTransferService,
    private modalService: ModalService
  ) { }

  ngOnInit() {
    this.initSubscribers();
    this.tituloManagementService.getTitulos();
  }

  initSubscribers() {
    this.tituloManagementService.GetTitulosSuccess.subscribe((data) => {
      this.titulosList = data.titulos;
    })

    this.tituloManagementService.GetTitulosError.subscribe((error) => {
      this.showError(error);
    })

  }

  searchList(filter: string) {
    this.filterArgs = filter;
  }

  showError(msg: string) {
    this.dataTransferService.sendToastMessage({
      success: false,
      message: msg,
    });
  }

  addTitulo() {
    this.modalService
      .open(ModalTituloComponent, { toastReference: this.toastReference })
      .then(() => {
        this.tituloManagementService.getTitulos();
      })
  }

}

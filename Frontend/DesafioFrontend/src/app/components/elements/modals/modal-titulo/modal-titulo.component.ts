import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { DataTransferService } from 'src/app/core/data-transfer.service';
import { Parcela } from 'src/app/interfaces/parcela.interface';
import { Titulo } from 'src/app/interfaces/titulo.interface';
import { TituloManagementService } from 'src/app/pages/titulo-management/titulo-management.service';
import { ToastMessageComponent } from '../../toast-message/toast-message.component';

@Component({
  selector: 'app-modal-titulo',
  templateUrl: './modal-titulo.component.html',
  styleUrls: ['./modal-titulo.component.css']
})
export class ModalTituloComponent implements OnInit, OnDestroy {
  
  @Input() modalParameter: any;
  toastReferenceComponent: ToastMessageComponent;
  novoTitulo: Titulo;
  novasParcelas: Parcela[];

  postTituloSuccessSubs;
  postTituloErrorSubs;

  constructor(
    private modalInstance: NgbActiveModal,
    private tituloManagementService: TituloManagementService,
    private dataTransfer: DataTransferService) { }

  ngOnInit(): void {
    this.novoTitulo = new Titulo();
    this.novasParcelas = [];
    this.toastReferenceComponent = this.modalParameter.toastReference;
    this.initSubscribers();
  }

  ngOnDestroy() {
    this.postTituloErrorSubs.unsubscribe();
    this.postTituloSuccessSubs.unsubscribe();
  }

  initSubscribers() {
    this.postTituloSuccessSubs = this.tituloManagementService.PostTituloSuccess.subscribe(() => {
      this.showSuccess();
      this.modalInstance.close();
    })
    
    this.postTituloErrorSubs = this.tituloManagementService.PostTituloError.subscribe((error) => {
      this.showError(error);
      this.modalInstance.dismiss();
    })
  }

  showSuccess() {
    this.dataTransfer.sendToastMessage({
      success: true,
      message: "Sucesso ao criar Titulo"
    });
  }

  showError(msg?: string) {
    this.dataTransfer.sendToastMessage({
      success: false,
      message: msg
    });
  }

  addTitulo() {
    this.novoTitulo.parcelas = this.novasParcelas;
    this.tituloManagementService.postTitulo(this.novoTitulo);
  }

  addNewParcela() {
    const numeroParcela = this.novasParcelas.length;
    let parcela = new Parcela();
    parcela.numero = numeroParcela + 1;
    parcela.valor = 0.00;
    parcela.dataVencimento = new Date(Date.now()).toISOString().split('T')[0];
    
    this.novasParcelas.push(parcela);
  }

  closeModal() {
    this.modalInstance.close();
  }
}

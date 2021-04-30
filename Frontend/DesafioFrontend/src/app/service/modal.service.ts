import { Injectable } from "@angular/core";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})

export class ModalService {
  constructor(private modalService: NgbModal) { }

  open(component, params?: any): Promise<any> {
    const modalRef = this.modalService.open(component, {
      centered: true,
      keyboard: false,
      backdrop: 'static'
    });

    modalRef.componentInstance.modalParameter = params;

    return modalRef.result;
  }
}
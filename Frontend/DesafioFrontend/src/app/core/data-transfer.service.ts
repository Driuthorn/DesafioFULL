import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class DataTransferService {
    private toastMessages = new Subject<any>();

    sendToastMessage(msg: any) {
        this.toastMessages.next(msg);
    }
    
    getToastMessage() {
        return this.toastMessages.asObservable();
    }
}
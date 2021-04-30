
import { EventEmitter, Injectable, Output } from '@angular/core';
import { HttpService } from '../../core/http.service';

@Injectable({
    providedIn: 'root'
})
export class TituloManagementService {
    response: [];

    @Output() GetTitulosSuccess: EventEmitter<any> = new EventEmitter();
    @Output() GetTitulosError: EventEmitter<any> = new EventEmitter();

    @Output() PostTituloSuccess: EventEmitter<any> = new EventEmitter();
    @Output() PostTituloError: EventEmitter<any> = new EventEmitter();

    constructor( private httpService: HttpService) { }
    
    getTitulos() {
        this.httpService.get('/api/v1/titulo')
            .then(response => {
                this.response = response;
                this.GetTitulosSuccess.emit(this.response);
            })
            .catch(error => {
                this.GetTitulosError.emit(error);
            });
    }

    postTitulo(command) {
        this.httpService.post('/api/v1/titulo', command)
            .then(response => {
                this.PostTituloSuccess.emit();
            })
            .catch(error => {
                this.PostTituloError.emit(error);
            })
    }
}
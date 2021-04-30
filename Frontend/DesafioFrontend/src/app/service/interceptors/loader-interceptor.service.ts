import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http'
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { DataTransferService } from '../../core/data-transfer.service';
import { LoaderService } from '../loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
    private requests: HttpRequest<any>[] = [];

    constructor(
        private loaderService: LoaderService,
        private DataTransferService: DataTransferService) { }
    
    removeRequest(request: HttpRequest<any>) {
        const index = this.requests.indexOf(request);
        if (index >= 0) {
            this.requests.splice(index, 1);
        }
        
        this.loaderService.isLoading.next(this.requests.length > 0);
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.requests.push(request);

        this.loaderService.isLoading.next(true);
        return new Observable(observer => {
            const subscription = next.handle(request)
                .subscribe(
                    event => {
                        if (event instanceof HttpResponse) {
                            this.removeRequest(request);
                            observer.next(event);
                        }
                    },
                    err => {
                        if (err instanceof HttpErrorResponse) {
                            this.DataTransferService.sendError(err);
                        }
                        this.removeRequest(request);
                        observer.error(err);
                    },
                    () => {
                        this.removeRequest(request);
                        observer.complete();
                    })
                return () => {
                    this.removeRequest(request);
                    subscription.unsubscribe();
                };
        });
    }
}
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'


@Injectable({
    providedIn: 'root'
})

export class HttpService {
    constructor(
        private http: HttpClient,
    ) { }

    createHeader() {
        const headers = new HttpHeaders({
            Pragma: 'no-cache',
            Accept: 'application/json',
            'Cache-control': 'no-cache',
            'Content-Type': 'application/json',
        });

        return headers;
    }

    get(url: string): Promise<any> {
        const headers = this.createHeader();
        const options = { headers };
        const promise = new Promise<any>((resolve, reject) => {
            this.http
                .get(environment.desafioFullApiUrl + url, options)
                .toPromise()
                .then(
                    (response) => {
                        resolve(response);
                    },
                    (error) => {
                        reject(error);
                    }
                );
        })

        return promise;
    }

    post(url: string, body: any): Promise<any> {
        const headers = this.createHeader();
        const options = { headers };
        const promise = new Promise<any>((resolve, reject) => {
            this.http
                .post(environment.desafioFullApiUrl + url, body, options)
                .toPromise()
                .then(
                    (response) => {
                        resolve(response);
                    },
                    (error) => {
                        reject(error);
                    }
                );
        });

        return promise;
    }
}

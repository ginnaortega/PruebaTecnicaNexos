import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class HttpFactoryService {

  constructor(private _http: HttpClient, private config: AppConfig) { }

  // ApiEndPoint = this.config.getConfig('configuracion')['ApiEndpint'];
  ApiEndPoint = 'https://localhost:44327/api/';

  get(endpoint, data) {
    return new Promise((resolve, reject) => {
      this._http.get(this.ApiEndPoint + endpoint + data)
      .subscribe((results) => {
        resolve(results);
      }, (error) => {
        reject(error);
      });
    });
  }  
  
}

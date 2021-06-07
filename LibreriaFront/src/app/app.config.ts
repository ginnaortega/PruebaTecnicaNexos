import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AppConfig {

    private config: Object = null;

    constructor(private http: HttpClient) {
    }

    public getConfig(key: any) {
        return this.config[key];
    }

    public load() {
        return new Promise((resolve, reject) => {
           this.http.get('assets/config.json')
           .subscribe(res => {
               this.config = res;
               resolve(res);           
           }, (error: any ) => {
               console.log('Error en lectura de archivo de configuración');
           });
        });
    }
}

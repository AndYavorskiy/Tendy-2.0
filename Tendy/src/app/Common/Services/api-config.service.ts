import { Injectable } from '@angular/core';
import { Headers, RequestOptionsArgs } from "@angular/http";

@Injectable()
export class ConfigService {

    public readonly apiUrl: string = 'http://localhost:53015/api/';

    private getRequestHeaders() {
	   let headers = new Headers();
	   headers.append('Content-Type', 'application/json');

	   let authToken = localStorage.getItem('auth_token');
	   if (!!authToken) {
		  headers.append('Authorization', `Bearer ${authToken}`);
	   }

	   return headers;
    }

    public getRequestOptions(params?: any): RequestOptionsArgs {
	   return {
		  params: params,
		  headers: this.getRequestHeaders()
	   }
    }
}
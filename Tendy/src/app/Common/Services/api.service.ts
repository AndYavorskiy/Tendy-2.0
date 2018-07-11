import { map, catchError } from "rxjs/operators";

import { Injectable } from '@angular/core';
import { Http } from '@angular/http'

import { ApiErrorHandler } from "../utils";
import { ConfigService } from "./api-config.service";

@Injectable()
export class ApiService {

    constructor(
	   private _http: Http,
	   private configServ: ConfigService
    ) { }

    public get<T>(url: string, params?: any) {
	   return this._http
		  .get(this.configServ.apiUrl + url, this.configServ.getRequestOptions(params))
		  .pipe(
		  map(response => response.json()),
		  catchError(ApiErrorHandler.handleError)
		  );
    }

    public post<T>(url: string, body: any) {
	   return this._http
		  .post(this.configServ.apiUrl + url, body, this.configServ.getRequestOptions())
		  .pipe(
		  map(response => response.json()),
		  catchError(ApiErrorHandler.handleError)
		  );
    }

    public put<T>(url: string, body: any) {
	   return this._http
		  .put(this.configServ.apiUrl + url, body, this.configServ.getRequestOptions())
		  .pipe(
		  map(response => response.json()),
		  catchError(ApiErrorHandler.handleError)
		  );
    }

    public delete<T>(url: string, body?: any) {
	   return this._http
		  .delete(this.configServ.apiUrl + url, this.configServ.getRequestOptions(body))
		  .pipe(
		  map(response => response.json()),
		  catchError(ApiErrorHandler.handleError)
		  );
    }
}
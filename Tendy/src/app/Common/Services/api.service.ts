import { map } from "rxjs/operator/map";
import { Observable } from "rxjs/Observable";

import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptionsArgs } from '@angular/http'

import { ApiErrorHandler } from "../utils";
import { ConfigService } from "./api-config.service";

@Injectable()
export class ApiService {

  constructor(
    private _http: Http,
    private configServ: ConfigService
  ) { }

  public get<T>(url: string, params?: any): Observable<T> {
    return this._http
      .get(this.configServ.apiUrl + url, this.configServ.getRequestOptions(params))
      .map(response => response.json() as T)
      .catch(ApiErrorHandler.handleError);
  }

  public post<T>(url: string, body: any): Observable<T> {
    return this._http
      .post(this.configServ.apiUrl + url, body, this.configServ.getRequestOptions())
      .map(response => response.json() as T)
      .catch(ApiErrorHandler.handleError);
  }

  public put<T>(url: string, body: any): Observable<T> {
    return this._http
      .put(this.configServ.apiUrl + url, body, this.configServ.getRequestOptions())
      .map(response => response.json() as T)
      .catch(ApiErrorHandler.handleError);
  }

  public delete<T>(url: string, body?: any): Observable<T> {
    return this._http
      .delete(this.configServ.apiUrl + url, this.configServ.getRequestOptions(body))
      .map(response => response.json() as T)
      .catch(ApiErrorHandler.handleError);
  }
}

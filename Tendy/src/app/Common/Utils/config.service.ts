import { Injectable } from '@angular/core';
import { RequestOptions, Http, Headers } from "@angular/http";

@Injectable()
export class ConfigService {

    _apiURI: string;

    constructor() {
        this._apiURI = 'http://localhost:5000/api/';
    }

    public getRequestOptions() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return { headers: headers };
    }

    public getApiURI() {
        return this._apiURI;
    }
}
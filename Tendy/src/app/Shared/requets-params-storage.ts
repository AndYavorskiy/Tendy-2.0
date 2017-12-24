import { RequestOptions, Http, Headers } from "@angular/http";
import { Injectable } from "@angular/core";

@Injectable()
export class RequetsParamsStorage {

    public static getRequestOptions() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return  { headers: headers };
    }

    public static readonly idea: string = "api/idea/";
}
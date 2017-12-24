import "rxjs/add/operator/map";

import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http'
import { RequetsParamsStorage } from "../../Shared/requets-params-storage";
import { Observable } from "rxjs/Observable";
import { IdeaModel } from "../Models/idea.model";
import { map } from "rxjs/operator/map";

@Injectable()
export class IdeaService {

    private _baseUrl: string = "";

    constructor(private _http: Http) {
    }

    public getAllIdeas(): Observable<IdeaModel[]> {
        return this._http.get(this._baseUrl + RequetsParamsStorage.idea,  RequetsParamsStorage.getRequestOptions())
        .map((response) => 
        { return response.json() as IdeaModel[]});
    }

    private parseData<T>(res: Response)  {
        return res.json() || Array<T>();
    }
}

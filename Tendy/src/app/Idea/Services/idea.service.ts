import "rxjs/add/operator/map";
import { map } from "rxjs/operator/map";
import { Observable } from "rxjs/Observable";

import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http'
import { IdeaModel } from "../Models/idea.model";
import { ConfigService } from "../../Common/Utils/config.service";

@Injectable()
export class IdeaService {

    private _baseUrl: string = "idea/";

    constructor(
        private _http: Http,
        private configService: ConfigService
    ) {
    }

    public getAllIdeas(): Observable<IdeaModel[]> {
        return this._http
            .get(this.configService.getApiURI() + this._baseUrl, this.configService.getRequestOptions())
            .map((response) => { return response.json() as IdeaModel[] });
    }
}

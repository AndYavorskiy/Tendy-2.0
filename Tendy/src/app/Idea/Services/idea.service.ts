import { map } from "rxjs/operator/map";
import { Observable } from "rxjs/Observable";

import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http'

import { IdeaModel, SearchFilter } from "../Models";
import { ApiService } from "../../Common/Auxiliary";
import { AggregateContent } from "../../Common/Models";

@Injectable()
export class IdeaService {

    private readonly baseUrl = "idea/";;

    constructor(
        private _http: Http,
        private api: ApiService
    ) { }

    search(filter: SearchFilter): Observable<AggregateContent<IdeaModel>> {
        return this.api.get<AggregateContent<IdeaModel>>(this.baseUrl + "search", filter);
    }

    get(id: number): Observable<IdeaModel> {
        return this.api.get<IdeaModel>(this.baseUrl + JSON.stringify(id));
    }

    create(model: IdeaModel): Observable<IdeaModel> {
        return this.api.post<IdeaModel>(this.baseUrl, model);
    }

    update(model: IdeaModel): Observable<IdeaModel> {
        return this.api.put<IdeaModel>(this.baseUrl, model);
    }

    delete(id: number): Observable<boolean> {
        return this.api.delete(this.baseUrl + JSON.stringify(id));
    }
}
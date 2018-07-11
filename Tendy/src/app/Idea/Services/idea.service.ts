import { Injectable } from '@angular/core';

import { IdeaModel, SearchFilter } from "../models";
import { ApiService } from "../../common/services";
import { AggregateContent } from "../../common/models";

@Injectable()
export class IdeaService {

    private readonly baseUrl = "idea/";

    constructor(private api: ApiService) { }

    public search(filter: SearchFilter) {
	   return this.api.get<AggregateContent<IdeaModel>>(this.baseUrl + "search", filter);
    }

    public get(id: number) {
	   return this.api.get<IdeaModel>(this.baseUrl + JSON.stringify(id));
    }

    public create(model: IdeaModel) {
	   return this.api.post<IdeaModel>(this.baseUrl, model);
    }

    public update(model: IdeaModel) {
	   return this.api.put<IdeaModel>(this.baseUrl, model);
    }

    public delete(id: number) {
	   return this.api.delete<boolean>(this.baseUrl + JSON.stringify(id));
    }
}
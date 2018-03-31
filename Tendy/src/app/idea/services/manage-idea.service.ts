import { map } from "rxjs/operator/map";
import { Observable } from "rxjs/Observable";

import { Injectable, Inject } from '@angular/core';

import { IdeaModel, SearchFilter } from "../models";
import { ApiService } from "../../common/services";
import { AggregateContent } from "../../common/models";

@Injectable()
export class ManageIdeaService {

    private readonly baseUrl = "manage-idea/";

    constructor(private api: ApiService) { }

    updateJoinRequest(ideaId: number): Observable<boolean> {
        return this.api.put<boolean>(this.baseUrl + "join", ideaId);
    }
}
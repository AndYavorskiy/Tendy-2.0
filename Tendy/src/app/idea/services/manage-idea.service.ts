import { map } from "rxjs/operator/map";
import { Observable } from "rxjs/Observable";

import { Injectable, Inject } from '@angular/core';

import { IdeaModel, SearchFilter, Request } from "../models";
import { ApiService } from "../../common/services";
import { AggregateContent } from "../../common/models";

@Injectable()
export class ManageIdeaApiService {

    private readonly baseUrl = "manage-idea/";

    constructor(private api: ApiService) { }

    updateJoinRequest(ideaId: number): Observable<boolean> {
        return this.api.put<boolean>(this.baseUrl + "join", ideaId);
    }

    getRequests(ideaId: number): Observable<Request[]> {
        return this.api.get<Request[]>(this.baseUrl + "requests", { ideaId: ideaId });
    }

    confirmRequest(ideaId: number, request: Request): Observable<boolean> {
        return this.api.get<boolean>(this.baseUrl + "confirm-request", { ideaId: ideaId, requestId: request.id, userId: request.applicationUserId });
    }
}
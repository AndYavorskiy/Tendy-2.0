import { Injectable } from '@angular/core';

import { Request } from "../models";
import { ApiService } from "../../common/services";

@Injectable()
export class ManageIdeaApiService {

    private readonly baseUrl = "manage-idea/";

    constructor(private api: ApiService) { }

    public updateJoinRequest(ideaId: number) {
        return this.api.put<boolean>(this.baseUrl + "join", ideaId);
    }

    public getRequests(ideaId: number) {
        return this.api.get<Request[]>(this.baseUrl + "requests", { ideaId: ideaId });
    }

    public confirmRequest(ideaId: number, request: Request) {
        return this.api.get<boolean>(this.baseUrl + "confirm-request", { ideaId: ideaId, requestId: request.id, userId: request.applicationUserId });
    }
}
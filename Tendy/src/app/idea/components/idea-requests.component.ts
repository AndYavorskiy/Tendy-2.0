import * as _ from 'lodash';

import { Component, Input, OnChanges } from '@angular/core';

import { ManageIdeaApiService } from '../services';
import { Request } from "../models"

@Component({
    selector: 'app-idea-requests',
    templateUrl: './idea-requests.component.html',
    styleUrls: ['./idea-requests.component.scss']
})
export class IdeaRequestsComponent implements OnChanges {

    @Input()
    public ideaId: number;

    public acceptedRequests: Request[] = [];
    public rejectedRequests: Request[] = [];

    constructor(
        private manageIdeaApi: ManageIdeaApiService
    ) {
    }

    ngOnChanges(): void {
        this.manageIdeaApi
            .getRequests(this.ideaId)
            .subscribe(
            result => {
                this.acceptedRequests = _.filter(result, item => item.isAccepted);
                this.rejectedRequests = _.filter(result, item => !item.isAccepted);
            },
            error => alert(error));
    }

    updateRequest(request: Request) {

        request.isAccepted = !request.isAccepted; 

        this.manageIdeaApi
            .confirmRequest(this.ideaId, request)
            .subscribe(
            result => {
                if (request.isAccepted) {
                    this.acceptedRequests.push(request);
                    this.rejectedRequests.splice(this.rejectedRequests.indexOf(request), 1);
                }
                else {
                    this.rejectedRequests.push(request);
                    this.acceptedRequests.splice(this.acceptedRequests.indexOf(request), 1);
                }
            },
            error => {
                request.isAccepted = !request.isAccepted; 
                alert("Error");
            });
    }
}
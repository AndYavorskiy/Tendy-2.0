import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IdeaService, ManageIdeaApiService } from '../services';
import { IdeaModel } from '../models';

@Component({
    selector: 'app-idea-details',
    templateUrl: './idea-details.component.html',
    styleUrls: ['./idea-details.component.scss']
})
export class IdeaDetailsComponent implements OnInit {

    idea: IdeaModel;
    errors: string;
    success: string;
    loading: boolean = true;

    constructor(private route: ActivatedRoute,
        private ideaService: IdeaService,
        private manageIdeaService: ManageIdeaApiService,
    ) { }

    ngOnInit() {
        this.route.params
            .subscribe(params => {
                this.ideaService
                    .get(+params['id'])
                    .subscribe(
                    idea => {
                        this.idea = idea;
                        this.loading = false;
                    },
                    error => {
                        this.errors = error
                    });
            });
    }

    public updateJoinRequest() {
        this.idea.isUserJoined = !this.idea.isUserJoined;

        this.manageIdeaService
            .updateJoinRequest(this.idea.id)
            .subscribe(result => {
                alert("success");
            },
            error => {
                alert("error: " + error);
                this.idea.isUserJoined = !this.idea.isUserJoined;
            });
    }
}
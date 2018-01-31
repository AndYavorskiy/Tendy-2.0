import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IdeaService } from '../services';
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

    constructor(private route: ActivatedRoute,
        private ideaService: IdeaService) { }

    ngOnInit() {
        this.route.params
            .subscribe(params => {
                this.ideaService.get(+params['id'])
                    .subscribe(idea => this.idea = idea)
            });
    }
}
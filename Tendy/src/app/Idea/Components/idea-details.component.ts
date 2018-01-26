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

    constructor(route: ActivatedRoute,
        private ideaService: IdeaService) {
        route.params.subscribe(params => console.log("side menu id parameter", params['id']));
    }

    ngOnInit() {
    }
}
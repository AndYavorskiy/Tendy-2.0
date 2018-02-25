import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { IdeaModel } from '../models';
import { IdeaService } from '../services';

@Component({
    selector: 'app-idea-manage',
    templateUrl: './idea-manage.component.html',
    styleUrls: ['./idea-manage.component.scss']
})
export class IdeaManageComponent implements OnInit {

    loading: boolean = true;
    errors: string;
    success: string;

    manageIdeaId?: number;
    idea: IdeaModel;

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private ideaService: IdeaService) {
        activatedRoute.params.subscribe(
            params => {
                this.manageIdeaId = +params['id'] || null;
            });
    }

    ngOnInit() {
        if (!this.manageIdeaId) {
            this.router.navigate(['ideas/my'])
        }

        this.ideaService.get(this.manageIdeaId)
            .subscribe(
                data => {
                    this.idea = data;
                    this.loading = false;
                },
                error => this.router.navigate(['ideas/my'])
            );
    }

    delete() {
        this.ideaService
            .delete(this.idea.id)
            .subscribe(data => {
                if (data) {
                    this.router.navigate(['ideas/my']);
                }
                else {
                    error => alert(error)
                }
            }, error => alert(error));
    }
}
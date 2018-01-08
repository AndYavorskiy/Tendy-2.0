import { Component, OnInit } from '@angular/core';
import { IdeaModel } from '../Models';
import { Router, ActivatedRoute } from '@angular/router';
import { IdeaService } from '../Services';

@Component({
    selector: 'app-idea-manage',
    templateUrl: './idea-manage.component.html',
    styleUrls: ['./idea-manage.component.scss']
})
export class IdeaManageComponent implements OnInit {

    manageIdeaId?: number;
    idea: IdeaModel;

    errors: string;
    success: string;

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
            this.router.navigate(['../my'])
        }

        this.ideaService.get(this.manageIdeaId)
            .subscribe(
            data => this.idea = data,
            error => this.router.navigate(['../my'])
            );
    }
}
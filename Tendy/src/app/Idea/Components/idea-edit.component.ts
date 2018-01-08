import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { IdeaService } from '../Services';
import { IdeaModel } from '../Models';

@Component({
    selector: 'app-idea-edit',
    templateUrl: './idea-edit.component.html',
    styleUrls: ['./idea-edit.component.scss']
})
export class IdeaEditComponent implements OnInit {

    isNewIdea: boolean;
    editIdeaId?: number;

    editIdea: IdeaModel;

    errors: string;
    success: string;

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private ideaService: IdeaService) {
        activatedRoute.params.subscribe(
            params => {
                this.isNewIdea = !params['id'];
                this.editIdeaId = +params['id'] || null;
            });
    }

    ngOnInit() {
        if (!this.isNewIdea) {
            this.ideaService.get(this.editIdeaId)
                .subscribe(
                data => this.editIdea = data,
                error => this.router.navigate(['../../ideas'])
                );
        }

        else {
            this.editIdea = new IdeaModel();
        }
    }

    save() {
        console.log(this.editIdea);
        if (this.isNewIdea) {
            this.add(this.editIdea);
        }
        else {
            this.edit(this.editIdea);
        }
    }

    add(addIdea: IdeaModel) {
        this.ideaService.create(addIdea)
            .subscribe(
            result => {
                this.success = "cuccessfuly added!";
                this.errors = "";
            }, error => {
                this.success = "";
                this.errors = error
            });
    }

    edit(editIdea: IdeaModel) {
        this.ideaService.update(editIdea)
            .subscribe(
            result => {
                this.success = "Changes seved successfuly!";
                this.errors = "";
            }, error => {
                this.success = "";
                this.errors = error
            });
    }
}
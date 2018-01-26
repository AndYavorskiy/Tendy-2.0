import { Component, OnInit } from '@angular/core';

import { IdeaService } from '../services';
import { IdeaModel, SearchFilter } from '../models';

@Component({
    selector: 'app-my-idea',
    templateUrl: './my-idea.component.html',
    styleUrls: ['./my-idea.component.scss']
})
export class MyIdeaComponent implements OnInit {

    page: number = 1;
    pageSize: number = 9;
    total: number;
    myIdeas: IdeaModel[];

    constructor(private ideaService: IdeaService) { }

    ngOnInit() {
        let filter = {
            isUserAuthor: true,
            page: this.page,
            pageSize: this.pageSize
        } as SearchFilter;

        this.ideaService.search(filter)
            .subscribe(
            res => {
                this.myIdeas = res.source;
                this.total = res.total;
            },
            error => console.log(error));
    }
}
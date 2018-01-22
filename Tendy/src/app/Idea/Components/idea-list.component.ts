import { Component, OnInit, Inject, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IdeaService } from '../Services';
import { IdeaModel, SearchFilter } from '../Models';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'app-idea-list',
  templateUrl: './idea-list.component.html',
  styleUrls: ['./idea-list.component.css']
})
export class IdeaListComponent implements OnInit {

  page: number = 1;
  pageSize: number = 12;
  total: number;

  ideas: IdeaModel[];

  constructor(route: ActivatedRoute,
    private ideaService: IdeaService) {
  }
  
  ngOnInit() {
    let filter = {
      page: this.page,
      pageSize: this.pageSize
    } as SearchFilter;

    this.ideaService.search(filter)
      .subscribe(
      res => {
        this.ideas = res.source;
        this.total = res.total;
      },
      error => console.log(error));
  }
}

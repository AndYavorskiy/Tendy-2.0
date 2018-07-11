import { Component, Input, OnInit } from '@angular/core';

import { AttachmentService } from '../services';
import { LinkModel } from '../../common/models';

@Component({
    selector: 'app-link-list',
    templateUrl: './link-list.component.html',
    styleUrls: ['./link-list.component.scss']
})
export class LinkListComponent implements OnInit {

    @Input()
    public ideaId: number;

    public links: LinkModel[] = [];

    constructor(
	   private attachmentApi: AttachmentService
    ) { }

    public ngOnInit() {
	   this.loadData();
    }

    public loadData() {
	   this.attachmentApi.getLinks(this.ideaId)
		  .subscribe(data => this.links = data)
    }
}
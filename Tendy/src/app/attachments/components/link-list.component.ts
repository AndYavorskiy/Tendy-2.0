import { Component, Input, OnChanges } from '@angular/core';

import { AttachmentService } from '../services';
import { LinkModel } from '../models/link.model';

@Component({
  selector: 'app-link-list',
  templateUrl: './link-list.component.html',
  styleUrls: ['./link-list.component.scss']
})
export class LinkListComponent implements OnChanges {

  @Input()
  public ideaId: number;

  public links: LinkModel[] = [];

  constructor(
    private attachmentApi: AttachmentService
  ) { }

  ngOnChanges() {
    this.loadData();
  }

  loadData() {
    this.attachmentApi.getLinks(this.ideaId)
      .subscribe(data => this.links = data)
  }
}
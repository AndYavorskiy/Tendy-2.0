import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { AttachmentService } from '../services';
import { LinkModel } from '../models';

@Component({
  selector: 'app-add-link',
  templateUrl: './add-link.component.html',
  styleUrls: ['./add-link.component.scss']
})
export class AddLinkComponent {

  @Input()
  public ideaId: number;

  @Output()
  public onSubmit: EventEmitter<void> = new EventEmitter<void>();

  public loading = true;

  public links: LinkModel[] = [];
  public editedLink: LinkModel = new LinkModel();

  constructor(private attachmentApi: AttachmentService) { }

  public loadData() {
    this.attachmentApi.getLinks(this.ideaId)
      .subscribe(
      data => {
        this.links = data,
          this.loading = false;
      },
      error => alert("error: " + error));
  }

  public submit() {
    if (this.editedLink.url && this.editedLink.title) {
      if (!this.editedLink.id) {
        this.links.push({
          id: -1,
          title: this.editedLink.title,
          url: this.editedLink.url,
          isPrivate: false,
          ideaId: this.ideaId,
          dateOfCreation: new Date()
        });
      }
      else {
        let index = this.links.findIndex(userFound => userFound.id === this.editedLink.id);
        this.links.splice(index, 1, this.editedLink);
      }

      this.editedLink = new LinkModel();
    }
  }

  public editLink(link: LinkModel) {
    this.editedLink = link;
  }

  public removeLink(item: LinkModel) {
    var index = this.links.indexOf(item as LinkModel, 0);
    if (index > -1) {
      this.links.splice(index, 1);
    }
  }

  public save() {
    this.attachmentApi.updateLinks(this.ideaId, this.links)
      .subscribe(
      data => {
        this.loading = true;
        this.loadData();
        this.onSubmit.emit();
        
        alert("success: " + data);
      },
      error => alert("error: " + error))
  }
}
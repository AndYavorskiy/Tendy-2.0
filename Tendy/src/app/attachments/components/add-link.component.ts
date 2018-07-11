import { BsModalService, BsModalRef, ModalDirective } from 'ngx-bootstrap';

import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';

import { AttachmentService } from '../services';
import { LinkModel } from '../../common/models';

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

    @ViewChild('mainModal') mainModal: ModalDirective;
    @ViewChild('confirmModel') confirmModel: ModalDirective;

    public links: LinkModel[] = [];
    public editedLink: LinkModel = new LinkModel();

    public loading: boolean = true;
    public isChanged: boolean;

    constructor(private modalService: BsModalService,
	   private attachmentApi: AttachmentService) { }

    public loadData() {
	   this.attachmentApi.getLinks(this.ideaId)
		  .subscribe(
		  data => {
			 this.links = data,
				this.loading = false;
		  },
		  error => alert("error: " + error));
    }

    public startInicialization() {
	   this.loading = true;
	   this.isChanged = false;
	   this.loadData();
    }

    public add() {
	   if (this.editedLink.url && this.editedLink.title) {
		  this.isChanged = true;

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
	   this.attachmentApi
		  .updateLinks(this.ideaId, this.links)
		  .subscribe(
		  data => {
			 this.loading = true;

			 if (data) {
				alert("success: " + data);
				this.onSubmit.emit();
				this.mainModal.hide();
			 } else {
				alert("error: can't save changes!")
			 }
		  },
		  error => alert("error: " + error));
    }

    public openModal() {
	   this.mainModal.show();
	   this.startInicialization();
    }

    public closeModal() {
	   if (this.isChanged) {
		  this.confirmModel.show();
	   }
	   else {
		  this.mainModal.hide();
	   }
    }

    public confirm(): void {
	   this.confirmModel.hide();
	   this.mainModal.hide();
    }

    public decline(): void {
	   this.confirmModel.hide();
    }
}
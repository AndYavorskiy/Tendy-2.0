import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';

import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';

import { AttachmentService } from '../services';
import { FileModel } from '../../common/models';

@Component({
    selector: 'app-add-file',
    templateUrl: './add-file.component.html',
    styleUrls: ['./add-file.component.scss']
})
export class AddFileComponent {

    @Input()
    public ideaId: number;

    @Output()
    public onSubmit: EventEmitter<void> = new EventEmitter<void>();

    @ViewChild('mainModal') mainModal: ModalDirective;
    @ViewChild('confirmModel') confirmModel: ModalDirective;

    public files: FileModel[] = [];

    public loading: boolean = true;
    public isChanged: boolean;

    constructor(private attachmentApi: AttachmentService) { }

    public loadData() {
	   this.attachmentApi.getFiles(this.ideaId)
		  .subscribe(
		  data => {
			 this.files = data,
				this.loading = false;
		  },
		  error => alert("error: " + error));
    }

    public startInicialization() {
	   this.loading = true;
	   this.isChanged = false;
	   this.loadData();
    }

    public onFilesSelected(files: FileModel[]) {
	   this.files.push(...(_.forEach(files, item => item.ideaId = this.ideaId)) as FileModel[]);

	   this.isChanged = true;
    }

    public removeFile(item: FileModel) {
	   var index = this.files.indexOf(item as FileModel, 0);
	   if (index > -1) {
		  this.files.splice(index, 1);
		  this.isChanged = true;
	   }
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

    public save() {
	   this.attachmentApi
		  .updateFiles(this.ideaId, this.files)
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
}
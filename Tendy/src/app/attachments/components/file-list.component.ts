import * as _ from 'lodash';

import { Component, OnInit, Input } from '@angular/core';

import { AttachmentService } from '../services';
import { FileModel } from '../../common/models';

@Component({
    selector: 'app-file-list',
    templateUrl: './file-list.component.html',
    styleUrls: ['./file-list.component.scss']
})
export class FileListComponent implements OnInit {

    @Input()
    public ideaId: number;

    public files: FileModel[] = [];

    constructor(
	   private attachmentApi: AttachmentService
    ) { }

    public ngOnInit() {
	   this.loadData();
    }

    public loadData() {
	   this.attachmentApi.getFiles(this.ideaId)
		  .subscribe(data => this.files = data)
    }

    public getFileIcon(file: FileModel) {

	   if (_.includes(["png", "jpeg", "gif", "jpg"], file.extension)) {
		  return "fa-file-image pink";
	   }
	   else if (_.includes(["doc", "docx"], file.extension)) {
		  return "fa-file-word dobger-blue";
	   }
	   else if (_.includes(["xls"], file.extension)) {
		  return "fa-file-excel excel";
	   }
	   else if (_.includes(["mp4"], file.extension)) {
		  return "fa-file-video coral";
	   }
	   else if (_.includes(["cs", "ts", "css", "html", "js"], file.extension)) {
		  return "fa-file-code dark";
	   }
	   else if (_.includes(["pdf"], file.extension)) {
		  return "fa-file-pdf danger";
	   }
	   else if (_.includes(["zip", "7zip"], file.extension)) {
		  return "fa-file-archive dart-green";
	   }
	   else {
		  return "fa-file-alt violet";
	   }
    }
}

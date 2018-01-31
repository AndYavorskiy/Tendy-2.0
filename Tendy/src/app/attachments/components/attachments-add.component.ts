import * as _ from 'lodash';

import { Component, OnInit } from '@angular/core';

import { Attachments, Link, FileModel } from '../models';
import { AttachmentService } from '../services';

@Component({
    selector: 'app-attachments-add',
    templateUrl: './attachments-add.component.html',
    styleUrls: ['./attachments-add.component.scss']
})
export class AttachmentsAddComponent implements OnInit {

    public ideaId: number = 1;
    public fileList: File[] = [];
    public linkList: string[] = [];
    public attachments: Attachments = new Attachments();

    constructor(
        private attachmentApi: AttachmentService
    ) { }

    ngOnInit() {
        this.attachments.Links

    }

    addLink(link: string) {
        if (!!link) {
            this.linkList.push(link);
            this.attachments.Links.push({ url: link } as Link);
        }
    }

    removeLink(item: string) {
        var index = this.linkList.indexOf(item, 0);
        if (index > -1) {
            this.linkList.splice(index, 1);
        }
    }

    onFilesSelected(files: File[]) {
        //this.fileList.push(...files);

        this.attachments.Files.push(...files as FileModel[]);
    }

    removeFile(item: File) {
        var index = this.fileList.indexOf(item, 0);
        if (index > -1) {
            this.fileList.splice(index, 1);
        }
    }

    submit() {
        this.attachmentApi.create(this.ideaId, this.attachments).subscribe(
            data => alert("success: " + data),
            error => alert("error: " + error))
    }
}

import * as _ from 'lodash';

import { Component, OnInit } from '@angular/core';

import { Attachments, LinkModel, FileModel } from '../models';
import { AttachmentService } from '../services';

@Component({
    selector: 'app-attachments-add',
    templateUrl: './attachments-add.component.html',
    styleUrls: ['./attachments-add.component.scss']
})
export class AttachmentsAddComponent implements OnInit {

    public ideaId: number = 1;
    public attachments: Attachments = new Attachments();

    constructor(
        private attachmentApi: AttachmentService
    ) { }

    ngOnInit() {
    }

    addLink(link: string) {
        this.attachments.Links.push({ url: link } as LinkModel);
    }

    removeLink(item: LinkModel) {
        var index = this.attachments.Links.indexOf(item, 0);
        if (index > -1) {
            this.attachments.Links.splice(index, 1);
        }
    }

    onFilesSelected(files: FileModel[]) {
        this.attachments.Files.push(...files as FileModel[]);
    }

    removeFile(item: FileModel) {
        var index = this.attachments.Files.indexOf(item as FileModel, 0);
        if (index > -1) {
            this.attachments.Files.splice(index, 1);
        }
    }

    submit() {
        this.attachmentApi.create(this.ideaId, this.attachments).subscribe(
            data => alert("success: " + data),
            error => alert("error: " + error))
    }
}

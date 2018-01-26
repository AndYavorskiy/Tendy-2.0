import * as _ from 'lodash';

import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-attachments-add',
    templateUrl: './attachments-add.component.html',
    styleUrls: ['./attachments-add.component.scss']
})
export class AttachmentsAddComponent implements OnInit {

    public fileList: File[] = [];
    public linkList: string[] = [];

    constructor() { }

    ngOnInit() {
    }

    onFilesSelected(files: File[]) {
        this.fileList.push(...files);
    }

    addLink(link: string) {
        if (!!link) {
            this.linkList.push(link);
        }
    }

    removeFile(item: File) {
        var index = this.fileList.indexOf(item, 0);
        if (index > -1) {
            this.fileList.splice(index, 1);
        }
    }

    removeLink(item: string) {
        var index = this.linkList.indexOf(item, 0);
        if (index > -1) {
            this.linkList.splice(index, 1);
        }
    }
}

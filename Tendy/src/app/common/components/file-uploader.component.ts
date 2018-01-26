import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'file-uploader',
    templateUrl: './file-uploader.component.html',
    styleUrls: ['./file-uploader.component.scss']
})
export class FileUploaderComponent implements OnInit {

    @Output() onSelect = new EventEmitter();

    constructor() { }

    ngOnInit() {
    }

    fileChange($event) {
        let fileList: File[] = [];
        let target: HTMLInputElement = $event.target as HTMLInputElement;

        for (var i = 0; i < target.files.length; i++) {
            fileList.push(target.files[i]);
        }

        this.onSelect.emit(fileList);
    }
}

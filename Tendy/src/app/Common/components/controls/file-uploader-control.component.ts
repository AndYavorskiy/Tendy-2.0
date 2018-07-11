import { Observable, forkJoin } from 'rxjs';
import { first } from 'rxjs/operators';

import { Component, Output, EventEmitter } from '@angular/core';

import { FileReaderService } from '../../services/file-reader.service';
import { FileModel } from '../../models';

@Component({
    selector: 'file-uploader-control',
    templateUrl: './file-uploader.component.html',
    styleUrls: ['./file-uploader.component.scss']
})
export class FileUploaderControlComponent {

    @Output() onSelect = new EventEmitter();

    constructor(private fireReader: FileReaderService) { }

    public fileChange($event) {
	   let fileList: File[] = [];
	   let target: HTMLInputElement = $event.target as HTMLInputElement;

	   for (var i = 0; i < target.files.length; i++) {
		  fileList.push(target.files[i]);
	   }

	   var tasks$: Observable<FileModel>[] = [];

	   for (let i = 0; i < fileList.length; i++) {
		  tasks$.push(this.fireReader.readFileAsBase64(fileList[i]).pipe(first()));
	   }

	   forkJoin(...tasks$)
		  .subscribe(results => this.onSelect.emit(results));
    }
}
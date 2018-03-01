import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';

import {
    Component,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';

import { FileReaderService } from '../services/file-reader.service';
import { FileModel } from '../../attachments/models';

@Component({
    selector: 'file-uploader',
    templateUrl: './file-uploader.component.html',
    styleUrls: ['./file-uploader.component.scss']
})
export class FileUploaderComponent implements OnInit {

    @Output() onSelect = new EventEmitter();

    constructor(private fireReader: FileReaderService) { }

    ngOnInit() {
    }

    fileChange($event) {
        let fileList: File[] = [];
        let target: HTMLInputElement = $event.target as HTMLInputElement;

        for (var i = 0; i < target.files.length; i++) {
            fileList.push(target.files[i]);
        }

        var tasks$: Observable<FileModel>[] = [];

        for (let i = 0; i < fileList.length; i++) {
            tasks$.push(this.fireReader.readFileAsBase64(fileList[i]).first());
        }

        Observable.forkJoin(...tasks$)
            .subscribe(results => this.onSelect.emit(results));
    }
}

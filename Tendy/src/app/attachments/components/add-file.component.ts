import { Component, OnInit, Input } from '@angular/core';

import { AttachmentService } from '../services';
import { FileModel } from '../models';

@Component({
  selector: 'app-add-file',
  templateUrl: './add-file.component.html',
  styleUrls: ['./add-file.component.scss']
})
export class AddFileComponent implements OnInit {

  @Input()
  public ideaId: number;
  
  public files: FileModel[] = [];

  constructor(
    private attachmentApi: AttachmentService
  ) { }

  ngOnInit() {
  }

  onFilesSelected(files: FileModel[]) {
    console.log(files);
    
    this.files.push(...files as FileModel[]);
  }

  removeFile(item: FileModel) {
    var index = this.files.indexOf(item as FileModel, 0);
    if (index > -1) {
      this.files.splice(index, 1);
    }
  }
}

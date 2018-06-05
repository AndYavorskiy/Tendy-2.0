import * as _ from "lodash";
import { Observable, ReplaySubject } from "rxjs";

import { Injectable } from '@angular/core';

import { FileModel } from "../../attachments/models";

@Injectable()
export class FileReaderService {

  constructor() { }

  public readFileAsBase64(fileToRead: File): Observable<FileModel> {
    let base64Observable = new ReplaySubject<FileModel>(1);
    let fileReader = new FileReader();

    fileReader.onload = event => {
      base64Observable.next(
        _.assign({},
          fileToRead,
          {
            name: fileToRead.name,
            dateOfCreation: new Date(),
            source: fileReader.result,
            extension: this.getExtension(fileToRead.name)
          } as FileModel
        ) as FileModel);
    };
    fileReader.readAsDataURL(fileToRead);

    return base64Observable;
  }

  private getExtension(fileName: string) {
    return _.last(fileName.split('.'));
  }
}

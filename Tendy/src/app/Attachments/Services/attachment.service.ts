import * as _ from "lodash";

import { Observable } from "rxjs";
import { Injectable } from '@angular/core';

import { ApiService } from '../../common/services';
import { LinkModel, FileModel } from "../models";

@Injectable()
export class AttachmentService {
  private readonly baseUrl = "attachments/";

  constructor(private api: ApiService) { }

  getLinks(ideaId: number): Observable<LinkModel[]> {
    return this.api.get<LinkModel[]>(this.baseUrl + "link/" + ideaId);
  }

  updateLinks(ideaId: number, links: LinkModel[]): Observable<boolean> {
    return this.api.post<boolean>(this.baseUrl + "link/" + ideaId, links);
  }

  getFiles(ideaId: number): Observable<FileModel[]> {
    return this.api.get<FileModel[]>(this.baseUrl + "file/" + ideaId);
  }

  updateFiles(ideaId: number, files: FileModel[]): Observable<boolean> {
    return this.api.post<boolean>(this.baseUrl + "file/" + ideaId, files);
  }
}

import { Injectable } from '@angular/core';

import { ApiService } from '../../common/services';
import { LinkModel, FileModel } from "../../common/models";

@Injectable()
export class AttachmentService {
    private readonly baseUrl = "attachments/";

    constructor(private api: ApiService) { }

    public getLinks(ideaId: number) {
	   return this.api.get<LinkModel[]>(this.baseUrl + "link/" + ideaId);
    }

    public updateLinks(ideaId: number, links: LinkModel[]) {
	   return this.api.post<boolean>(this.baseUrl + "link/" + ideaId, links);
    }

    public getFiles(ideaId: number) {
	   return this.api.get<FileModel[]>(this.baseUrl + "file/" + ideaId);
    }

    public updateFiles(ideaId: number, files: FileModel[]) {
	   return this.api.post<boolean>(this.baseUrl + "file/" + ideaId, files);
    }
}

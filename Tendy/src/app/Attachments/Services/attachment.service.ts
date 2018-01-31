import * as _ from "lodash";

import { Observable } from "rxjs/Observable";

import { Injectable } from '@angular/core';

import { ApiService } from '../../common/services';
import { Attachments } from '../models';

@Injectable()
export class AttachmentService {
  private readonly baseUrl = "attachments/";

  constructor(private api: ApiService) { }

  create(ideaId: number, attachments: Attachments): Observable<boolean> {
      return this.api.post<boolean>(this.baseUrl + ideaId, attachments);
  }
}

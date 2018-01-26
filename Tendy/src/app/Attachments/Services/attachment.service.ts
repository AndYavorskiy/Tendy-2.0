import { Injectable } from '@angular/core';

import { ApiService } from '../../common/services';

@Injectable()
export class AttachmentService {
  private readonly baseUrl = "attachment/";

  constructor(private api: ApiService) { }

}

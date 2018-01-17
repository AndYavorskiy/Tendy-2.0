import { Injectable } from '@angular/core';
import { ApiService } from '../../Common/Services';

@Injectable()
export class AttachmentService {
  private readonly baseUrl = "attachment/";

  constructor(private api: ApiService) { }

}

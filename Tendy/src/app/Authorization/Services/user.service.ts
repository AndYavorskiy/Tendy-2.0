import { Observable } from 'rxjs/Rx';

import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { ApiService } from "../../Common/Services";
import { UserRegistrationViewModel } from '../Models';

@Injectable()
export class UserService {

  baseUrl: string = 'account';

  constructor(
    private http: Http,
    private api: ApiService
  ) { }

  register(model: UserRegistrationViewModel): Observable<boolean> {
    return this.api.post<boolean>(this.baseUrl, model);
  }
}

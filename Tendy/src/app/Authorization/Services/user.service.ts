import { Injectable } from '@angular/core';

import { ApiService } from "../../common/services";
import { UserRegistrationViewModel } from '../models';

@Injectable()
export class UserService {

    baseUrl: string = 'account';

    constructor(private api: ApiService) { }

    public register(model: UserRegistrationViewModel) {
	   return this.api.post<boolean>(this.baseUrl, model);
    }
}
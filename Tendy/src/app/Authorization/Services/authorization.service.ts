import { BehaviorSubject } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { LocalStorage, ApiErrorHandler } from '../../common/utils';
import { AuthInfo } from '../../common/models';
import { ConfigService } from '../../common/services';

@Injectable()
export class AuthorizationService {

    _authNavStatusSource = new BehaviorSubject<AuthInfo>(new AuthInfo());
    authNavStatus$ = this._authNavStatusSource.asObservable();

    baseUrl: string = "auth/";
    authInfo: AuthInfo;

    constructor(
	   private http: Http,
	   private configServ: ConfigService
    ) {

	   this.authInfo = {
		  isSignedIn: LocalStorage.exists('auth_token'),
		  userName: LocalStorage.get("user_name")
	   };

	   this._authNavStatusSource.next(this.authInfo);
    }

    public login(email, password) {
	   return this.http
		  .post(this.configServ.apiUrl + this.baseUrl + 'login', JSON.stringify({ email, password }), this.configServ.getRequestOptions())
		  .pipe(
		  map(res => res.json()),
		  map(res => {
			 LocalStorage.setMany([
				{ key: "auth_token", value: res.auth_token },
				{ key: "user_name", value: res.user_name }
			 ]);

			 this.authInfo.isSignedIn = true;
			 this.authInfo.userName = res.user_name;
			 this._authNavStatusSource.next(this.authInfo);
			 return true;
		  }),
		  catchError(ApiErrorHandler.handleError)
		  );
    }

    public logout() {
	   LocalStorage.remove('auth_token');

	   this.authInfo.isSignedIn = false;
	   this.authInfo.userName = "";
	   this._authNavStatusSource.next(this.authInfo);
    }

    public isLoggedIn() {
	   return this.authInfo.isSignedIn;
    }
}
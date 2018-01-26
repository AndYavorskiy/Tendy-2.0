import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';

import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { LocalStrg, ApiErrorHandler } from '../../common/utils';
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
      isSignedIn: LocalStrg.exists('auth_token'),
      userName: LocalStrg.get("user_name")
    };

    this._authNavStatusSource.next(this.authInfo);
  }

  login(email, password) {

    return this.http
      .post(this.configServ.apiUrl + this.baseUrl + 'login', JSON.stringify({ email, password }), this.configServ.getRequestOptions())
      .map(res => res.json())
      .map(res => {
        LocalStrg.setMany([
          { key: "auth_token", value: res.auth_token },
          { key: "user_name", value: res.user_name }
        ]);

        this.authInfo.isSignedIn = true;
        this.authInfo.userName = res.user_name;
        this._authNavStatusSource.next(this.authInfo);
        return true;
      })
      .catch(ApiErrorHandler.handleError);
  }

  logout() {
    LocalStrg.remove('auth_token');

    this.authInfo.isSignedIn = false;
    this.authInfo.userName = "";
    this._authNavStatusSource.next(this.authInfo);
  }

  isLoggedIn() {
    return this.authInfo.isSignedIn;
  }
}

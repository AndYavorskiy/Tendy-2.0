import { Subscription } from 'rxjs/Subscription';

import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '../Authorization/Services';
import { LocalStrg } from '../Common/Utils';
import { AuthInfo } from '../Common/Models';

@Component({
  selector: 'nav-header',
  templateUrl: './nav-header.component.html',
  styleUrls: ['./nav-header.component.scss']
})
export class NavHeaderComponent implements OnInit {

  authInfo: AuthInfo;
  subscription: Subscription;
  
  constructor(private authorizeService: AuthorizationService) { }

  ngOnInit() {

    this.subscription = this.authorizeService.authNavStatus$
          .subscribe(status => this.authInfo = status);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  logout() {
    this.authorizeService.logout();
  }
}

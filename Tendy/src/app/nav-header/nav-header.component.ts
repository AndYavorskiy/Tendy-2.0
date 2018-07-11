import { Subscription } from 'rxjs';
import { Component, OnInit } from '@angular/core';

import { AuthorizationService } from '../authorization/services';
import { AuthInfo } from '../common/models';

@Component({
    selector: 'nav-header',
    templateUrl: './nav-header.component.html',
    styleUrls: ['./nav-header.component.scss']
})
export class NavHeaderComponent implements OnInit {

    authInfo: AuthInfo;
    subscription: Subscription;

    constructor(private authorizeService: AuthorizationService) { }

    public ngOnInit() {
	   this.subscription = this.authorizeService.authNavStatus$
		  .subscribe(status => this.authInfo = status);
    }

    public ngOnDestroy() {
	   this.subscription.unsubscribe();
    }

    public logout() {
	   this.authorizeService.logout();
    }
}
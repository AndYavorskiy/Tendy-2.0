import { Subscription } from 'rxjs';

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Credentials } from '../models';
import { AuthorizationService } from '../services';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

    subscription: Subscription;

    credentials: Credentials = { email: '', password: '' };
    errors: string;

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private authorizeService: AuthorizationService
    ) {

    }

    ngOnInit() {
        this.subscription = this.activatedRoute.queryParams.subscribe(
            params => this.credentials.email = params['email']);
    }

    signIn(value: Credentials) {
        console.log(this.credentials);

        this.authorizeService.login(value.email, value.password)
            .subscribe(
            result => {
                if (result) {
                    this.router.navigate(['../../ideas']);
                }
            },
            error => this.errors = error);

    }
}

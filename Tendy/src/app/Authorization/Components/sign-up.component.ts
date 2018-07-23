import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { UserRegistrationViewModel } from '../models';
import { AccountService } from '../services';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {

    errors: string;

    constructor(
	   private router: Router,
	   private activatedRoute: ActivatedRoute,
	   private accountService: AccountService
    ) {
    }

    public registrate(value: UserRegistrationViewModel) {
	   this.accountService.register(value)
		  .subscribe(
		  result => {
			 if (result) {
				this.router.navigate(['/authorize/sign-in'], { queryParams: { brandNew: true, email: value.email } });
			 }
		  },
		  errors => this.errors = errors);
    }
}
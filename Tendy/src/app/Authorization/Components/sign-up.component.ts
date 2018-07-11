import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { UserRegistrationViewModel } from '../models';
import { UserService } from '../services';

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
	   private userService: UserService
    ) {
    }

    public registrate(value: UserRegistrationViewModel) {
	   this.userService.register(value)
		  .subscribe(
		  result => {
			 if (result) {
				this.router.navigate(['/authorize/sign-in'], { queryParams: { brandNew: true, email: value.email } });
			 }
		  },
		  errors => this.errors = errors);
    }
}
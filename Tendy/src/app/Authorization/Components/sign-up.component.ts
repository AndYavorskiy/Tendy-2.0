import { Component, OnInit, Pipe} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { UserRegistrationViewModel } from '../Models';
import { UserService } from '../Services';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  errors: string;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private userService: UserService
  ) {

  }

  ngOnInit() {
  }

  registrate(value: UserRegistrationViewModel) {
    console.log(value);

    this.userService.register(value)
      .subscribe(
      result => {
        if (result) {
          console.log("Registration is successful");

          this.router.navigate(['/authorize/sign-in'], { queryParams: { brandNew: true, email: value.email } });
        }
      },
      errors => this.errors = errors);
  }
}

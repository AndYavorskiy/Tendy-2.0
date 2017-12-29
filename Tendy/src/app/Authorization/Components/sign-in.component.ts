import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Credentials } from '../Models/index';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorizationService } from '../Services/index';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  errors: string;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authorizeService: AuthorizationService
  ) {

  }

  ngOnInit() { }

  signIn({ value, valid }: { value: Credentials, valid: boolean }) {
    console.log(value);

    if (valid) {
      this.authorizeService.login(value.email, value.password)
        .subscribe(
        result => {
          if (result) {
            this.router.navigate(['']);
          }
        },
        error => this.errors = error);
    }
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { AuthorizationService, UserService } from './services';
import { SignUpComponent, SignInComponent } from './components';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AuthorizationRoutingModule
  ],
  declarations: [
    SignUpComponent,
    SignInComponent
  ],
  providers: [
    AuthorizationService,
    UserService
  ]
})
export class AuthorizationModule { }

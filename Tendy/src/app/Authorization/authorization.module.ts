import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { SignUpComponent, SignInComponent } from './Components/index';

@NgModule({
  imports: [
    CommonModule,
    AuthorizationRoutingModule
  ],
  declarations: [
    SignUpComponent,
    SignInComponent
  ]
})
export class AuthorizationModule { }

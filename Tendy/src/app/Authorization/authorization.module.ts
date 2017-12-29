import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }  from '@angular/forms';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { SignUpComponent, SignInComponent } from './Components/index';
import { AuthorizationService } from './Services/index';

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
  providers:[
    AuthorizationService
  ]
})
export class AuthorizationModule { }

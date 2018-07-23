import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { AuthorizationService, AccountService } from './services';
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
	   AccountService
    ]
})
export class AuthorizationModule { }

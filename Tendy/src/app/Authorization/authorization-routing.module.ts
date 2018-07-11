import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SignUpComponent, SignInComponent } from './components';

@NgModule({
    imports: [RouterModule.forChild([
	   {
		  path: 'authorize',
		  children: [
			 { path: 'sign-up', component: SignUpComponent },
			 { path: 'sign-in', component: SignInComponent },
		  ]
	   }
    ])],
    exports: [RouterModule]
})
export class AuthorizationRoutingModule { }
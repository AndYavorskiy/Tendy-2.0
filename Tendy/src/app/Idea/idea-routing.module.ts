import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { IdeaService } from './services';

import {
    IdeaLayoutComponent,
    IdeaListComponent,
    IdeaSideMenuComponent,
    IdeaEditComponent,
    IdeaDetailsComponent,
    MyIdeaComponent,
    IdeaManageComponent
} from './components';

@NgModule({
    imports: [RouterModule.forChild([
	   {
		  path: 'ideas',
		  component: IdeaLayoutComponent,
		  children: [
			 {
				path: '',
				component: IdeaListComponent
			 },
			 {
				path: '',
				outlet: "sidemenu",
				component: IdeaSideMenuComponent
			 },
			 {
				path: 'add',
				component: IdeaEditComponent
			 },
			 {
				path: 'edit/:id',
				component: IdeaEditComponent
			 },
			 {
				path: 'details/:id',
				component: IdeaDetailsComponent
			 },
			 {
				path: 'my',
				component: MyIdeaComponent
			 },
			 {
				path: 'manage/:id',
				component: IdeaManageComponent
			 },
		  ]
	   }
    ])],
    exports: [
	   RouterModule
    ],
    providers: [
	   IdeaService
    ]
})
export class IdeaRoutingModule { }
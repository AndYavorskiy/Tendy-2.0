import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IdeaService } from './Services';

import {
  IdeaLayoutComponent,
  IdeaListComponent,
  IdeaSideMenuComponent,
  IdeaEditComponent,
  IdeaDetailsComponent,
  MyIdeaComponent
} from './Components';

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

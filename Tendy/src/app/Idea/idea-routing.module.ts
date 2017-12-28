import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IdeaService } from './Services/idea.service';

import {
  IdeaLayoutComponent,
  IdeaListComponent,
  IdeaSideMenuComponent
} from './Components/index';

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
        }
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

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IdeaRoutingModule } from './idea-routing.module';
import {
  IdeaListComponent,
  IdeaLayoutComponent,
  IdeaSideMenuComponent
} from './Components/index';

@NgModule({
  imports: [
    CommonModule,
    IdeaRoutingModule
  ],
  declarations: [
    IdeaListComponent, 
    IdeaLayoutComponent, 
    IdeaSideMenuComponent, 
  ]
})
export class IdeaModule { }

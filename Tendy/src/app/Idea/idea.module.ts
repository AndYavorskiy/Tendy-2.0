import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IdeaRoutingModule } from './idea-routing.module';
import { IdeaService } from './Services/index';

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
  ],
  providers: [
    IdeaService
  ]
})
export class IdeaModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IdeaRoutingModule } from './idea-routing.module';
import { IdeaService } from './Services';

import {
  IdeaListComponent,
  IdeaLayoutComponent,
  IdeaSideMenuComponent,
  IdeaEditComponent,
  IdeaDetailsComponent
} from './Components';
import { MyIdeaComponent } from './Components/my-idea.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IdeaRoutingModule
  ],
  declarations: [
    IdeaListComponent,
    IdeaLayoutComponent,
    IdeaSideMenuComponent,
    IdeaEditComponent,
    IdeaDetailsComponent,
    MyIdeaComponent,
  ],
  providers: [
    IdeaService
  ]
})
export class IdeaModule { }

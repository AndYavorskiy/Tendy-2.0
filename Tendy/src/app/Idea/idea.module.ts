import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IdeaRoutingModule } from './idea-routing.module';
import { IdeaListComponent } from './Components/idea-list.component';

@NgModule({
  imports: [
    CommonModule,
    IdeaRoutingModule
  ],
  declarations: [IdeaListComponent]
})
export class IdeaModule { }

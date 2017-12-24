import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IdeaListComponent } from './Components/idea-list.component';
import { IdeaService } from './Services/idea.service';

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'ideas',
      children: [
        { path: '', redirectTo: 'all', pathMatch: 'full' },
        { path: 'all', component: IdeaListComponent }
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

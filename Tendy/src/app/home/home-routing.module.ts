import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeLayoutComponent } from './components/home-layout.component';

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'home',
      component: HomeLayoutComponent,
      children: [
        {
          path: '',
          component: HomeLayoutComponent
        }
      ]
    }
  ])],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

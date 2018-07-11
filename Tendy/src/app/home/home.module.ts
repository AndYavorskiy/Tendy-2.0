import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeLayoutComponent } from './components';
import { SharedModule } from '../common/shared.module';

@NgModule({
    imports: [
	   CommonModule,
	   HomeRoutingModule,
	   SharedModule,
    ],
    declarations: [
	   HomeLayoutComponent
    ]
})
export class HomeModule { }
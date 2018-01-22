import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { IdeaModule } from './Idea/idea.module';
import { NavHeaderComponent } from './NavHeader/nav-header.component';
import { AuthorizationModule } from './Authorization/authorization.module';
import { AppCommonModule } from './Common/app-common.module';

@NgModule({
    declarations: [
        AppComponent,
        NavHeaderComponent,
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([]),
        AppCommonModule.forRoot(),
        IdeaModule,
        AuthorizationModule,
    ],
    
    bootstrap: [AppComponent]
})
export class AppModule { }
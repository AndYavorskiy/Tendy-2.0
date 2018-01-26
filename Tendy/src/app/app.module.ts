import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { IdeaModule } from './idea/idea.module';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { AuthorizationModule } from './authorization/authorization.module';
import { ServiceProviderModule } from './common/app-common.module';
import { AttachmentsModule } from './attachments/attachments.module';
import { FileUploaderComponent } from './common/components';
import { SharedModule } from './common/shared.module';


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
        ServiceProviderModule.forRoot(),
        AuthorizationModule,
        SharedModule,
        IdeaModule,
        AttachmentsModule,
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
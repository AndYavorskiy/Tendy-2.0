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
import { ConfigService } from './Common/Utils/config.service';

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
    IdeaModule,
    AuthorizationModule
  ],
  providers: [ConfigService],
  bootstrap: [AppComponent]
})
export class AppModule { }

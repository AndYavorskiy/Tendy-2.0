import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { IdeaModule } from './Idea/idea.module';
import { RouterModule } from '@angular/router';
import { NavHeaderComponent } from './NavHeader/nav-header.component';
import { AuthorizationModule } from './Authorization/authorization.module';

@NgModule({
  declarations: [
    AppComponent,
    NavHeaderComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    RouterModule.forRoot([ ]),
    IdeaModule,
    AuthorizationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

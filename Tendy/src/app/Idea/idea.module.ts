import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../common/shared.module';
import { IdeaRoutingModule } from './idea-routing.module';
import { IdeaService } from './services';
import { ServiceProviderModule } from '../common/app-common.module';
import { AttachmentsModule } from '../attachments/attachments.module';

import {
    IdeaListComponent,
    IdeaLayoutComponent,
    IdeaSideMenuComponent,
    IdeaEditComponent,
    IdeaDetailsComponent,
    MyIdeaComponent,
    IdeaManageComponent
} from './components';

@NgModule({
    imports: [
        CommonModule,
        ServiceProviderModule,
        FormsModule,
        IdeaRoutingModule,
        AttachmentsModule,
        SharedModule,

    ],
    declarations: [
        IdeaListComponent,
        IdeaLayoutComponent,
        IdeaSideMenuComponent,
        IdeaEditComponent,
        IdeaDetailsComponent,
        MyIdeaComponent,
        IdeaManageComponent,
    ],
    providers: [
        IdeaService
    ]
})
export class IdeaModule { }
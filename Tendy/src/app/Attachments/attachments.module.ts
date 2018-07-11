import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../common/shared.module';
import { AttachmentsRoutingModule } from './attachments-routing.module';
import { AttachmentService } from './services';

import {
    AttachmentsLayoutComponent,
    AddFileComponent,
    AddLinkComponent,
    LinkListComponent,
    FileListComponent
} from './components';

@NgModule({
    imports: [
	   CommonModule,
	   AttachmentsRoutingModule,
	   FormsModule,
	   SharedModule,
    ],
    declarations: [
	   AttachmentsLayoutComponent,
	   AddLinkComponent,
	   AddFileComponent,
	   LinkListComponent,
	   FileListComponent,
    ],
    exports: [
	   AttachmentsLayoutComponent,
	   LinkListComponent,
	   FileListComponent,
    ],
    providers: [AttachmentService]
})
export class AttachmentsModule { }
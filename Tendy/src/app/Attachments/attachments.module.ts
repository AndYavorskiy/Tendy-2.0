
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AttachmentsRoutingModule } from './attachments-routing.module';
import { AttachmentService } from './services';
import {
    AttachmentsLayoutComponent,
    AttachmentsListComponent,
    AttachmentsAddComponent
} from './components';
import { FileUploaderComponent } from '../common/components/file-uploader.component';
import { SharedModule } from '../common/shared.module';

@NgModule({
    imports: [
        CommonModule,
        AttachmentsRoutingModule,
        SharedModule,
    ],
    declarations: [
        AttachmentsListComponent,
        AttachmentsLayoutComponent,
        AttachmentsAddComponent,
    ],
    exports: [
        AttachmentsListComponent,
        AttachmentsLayoutComponent,
    ],
    providers: [AttachmentService]
})
export class AttachmentsModule { }

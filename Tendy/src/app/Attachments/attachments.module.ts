import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AttachmentsRoutingModule } from './attachments-routing.module';
import { AttachmentEditComponent } from './Components/attachment-edit.component';
import { AttachmentService } from './Services/attachment.service';

@NgModule({
  imports: [
    CommonModule,
    AttachmentsRoutingModule
  ],
  declarations: [AttachmentEditComponent],
  providers: [AttachmentService]
})
export class AttachmentsModule { }

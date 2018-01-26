import { AlertModule, ModalModule, TooltipModule, CarouselModule } from 'ngx-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigService, ApiService } from './services';
import { FileUploaderComponent } from './components/file-uploader.component';

@NgModule({
    imports: [
        CommonModule,
        AlertModule.forRoot(),
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        CarouselModule.forRoot(),
        AngularFontAwesomeModule,
    ],
    declarations: [
        FileUploaderComponent
    ],
    exports: [
        AngularFontAwesomeModule,
        AlertModule,
        ModalModule,
        TooltipModule,
        FileUploaderComponent
    ]
})
export class SharedModule {
}

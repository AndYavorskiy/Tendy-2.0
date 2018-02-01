import { AlertModule, ModalModule, TooltipModule, CarouselModule } from 'ngx-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigService, ApiService } from './services';
import { FileUploaderComponent, SpinnerComponent } from './components';

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
        FileUploaderComponent,
        SpinnerComponent,
    ],
    exports: [
        AngularFontAwesomeModule,
        AlertModule,
        ModalModule,
        TooltipModule,
        FileUploaderComponent,
        SpinnerComponent,
    ]
})
export class SharedModule {
}

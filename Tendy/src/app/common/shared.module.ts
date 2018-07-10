import { AlertModule, ModalModule, TooltipModule, CarouselModule } from 'ngx-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ConfigService, ApiService } from './services';
import { FileUploaderComponent, SpinnerComponent } from './components';

import 'hammerjs';

@NgModule({
    imports: [
        CommonModule,
        AlertModule.forRoot(),
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        CarouselModule.forRoot(),
        AngularFontAwesomeModule,
        ReactiveFormsModule,
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
        ReactiveFormsModule,
    ]
})
export class SharedModule {
}

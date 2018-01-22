import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigService, ApiService } from './Services';
import { AlertModule, ModalModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    AlertModule.forRoot(),
    ModalModule.forRoot(),
  ],
  declarations: [
  ],
  exports: [
    AlertModule,
    ModalModule,
  ]
})
export class AppCommonModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppCommonModule,
      providers: [
        ConfigService,
        ApiService
      ]
    };
  }
}

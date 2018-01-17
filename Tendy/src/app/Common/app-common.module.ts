import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigService, ApiService } from './Services';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
  ],
  // providers: [
  //   ConfigService,
  //   ApiService
  // ],
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

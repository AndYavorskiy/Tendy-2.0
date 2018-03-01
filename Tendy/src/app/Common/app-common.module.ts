import { NgModule, ModuleWithProviders } from '@angular/core';

import { ConfigService, ApiService, FileReaderService} from './services';

@NgModule({})
export class ServiceProviderModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: ServiceProviderModule,
            providers: [
                ConfigService,
                ApiService,
                FileReaderService
            ],            
        };
    }
}
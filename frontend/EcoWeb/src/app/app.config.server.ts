import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';

import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    provideAnimations(), // required animations providers
    provideToastr(), // Toastr providers
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);

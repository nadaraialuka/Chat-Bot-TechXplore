import {ApplicationConfig, importProvidersFrom, provideZoneChangeDetection} from '@angular/core';
import {RouterModule} from '@angular/router';
import {appRoutes} from './app.routes';
import {provideHttpClient} from "@angular/common/http";

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({eventCoalescing: true}),
    // provideRouter(appRoutes),
    provideHttpClient(),
    importProvidersFrom(RouterModule.forRoot(appRoutes))
  ],
};

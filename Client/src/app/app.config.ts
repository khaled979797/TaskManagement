import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideAnimations(),
    provideClientHydration(), provideHttpClient(withFetch()),
    provideToastr({timeOut: 3000, positionClass:'toast-bottom-right', preventDuplicates:true}),
    importProvidersFrom(ModalModule.forRoot(), BsModalService)
  ]
};

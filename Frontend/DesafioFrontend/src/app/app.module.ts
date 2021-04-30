import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { LoaderComponent } from './components/shared/loader/loader.component';
import { TituloManagementRoutingModule } from './pages/titulo-management/module/titulo-management-routing.module';

import { SharedModule } from './shared.module';

// Services
import { HttpService } from '../app/core/http.service';
import { ModalService } from '../app/service/modal.service';
import { LoaderService } from '../app/service/loader.service';
import { LoaderInterceptor } from '../app/service/interceptors/loader-interceptor.service';
import { ToastMessageComponent } from './components/elements/toast-message/toast-message.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoaderComponent,
    ToastMessageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
    TituloManagementRoutingModule,
    SharedModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [
    HttpService,
    LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    ModalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { LoaderComponent } from './components/shared/loader/loader.component';
import { TituloManagementRoutingModule } from './pages/titulo-management/module/titulo-management-routing.module';
// Services
import { HttpService } from '../app/core/http.service';
import { LoaderService } from '../app/service/loader.service';
import { LoaderInterceptor } from '../app/service/interceptors/loader-interceptor.service';
import { FilterComponent } from './components/elements/filter/filter.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoaderComponent,
    FilterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    TituloManagementRoutingModule
  ],
  providers: [
    HttpService,
    LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

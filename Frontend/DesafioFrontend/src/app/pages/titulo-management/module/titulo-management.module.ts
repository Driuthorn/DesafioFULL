import { CommonModule } from "@angular/common";
import { LOCALE_ID, NgModule } from "@angular/core";
import { registerLocaleData } from '@angular/common';
import { FormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared.module";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { TituloManagementComponent } from "../titulo-management.component";
import { TituloManagementRoutingModule } from "./titulo-management-routing.module";
import { ModalTituloComponent } from '../../../components/elements/modals/modal-titulo/modal-titulo.component';

import localePt  from '@angular/common/locales/pt';

registerLocaleData(localePt , 'pt-BR')

@NgModule({
    declarations: [
        TituloManagementComponent,
        ModalTituloComponent,
    ],
    imports: [
        CommonModule,
        TituloManagementRoutingModule,
        SharedModule,
        FormsModule,
        NgbModule,
    ],
    entryComponents: [
        TituloManagementComponent,
    ],
    providers: [{provide: LOCALE_ID, useValue: "pt-BR"}]
})
export class TituloManagementModule { }
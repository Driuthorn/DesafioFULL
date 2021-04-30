import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TituloManagementComponent } from '../titulo-management.component';

const routes: Routes = [
    { path: '', component: TituloManagementComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TituloManagementRoutingModule { }

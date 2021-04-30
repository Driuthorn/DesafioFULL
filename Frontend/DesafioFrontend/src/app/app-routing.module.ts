import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'titulos',
    pathMatch: 'full'
  },
  {
    path: 'titulos',
    data: { name: 'titulo'},
    loadChildren: () => import('./pages/titulo-management/module/titulo-management.module').then(m => m.TituloManagementModule),
    
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

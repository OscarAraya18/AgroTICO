import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';
import { AfiliacionesComponent } from './vistas/administrador/afiliaciones/afiliaciones.component';
import { CategoriasComponent } from './vistas/administrador/categorias/categorias.component';
import { VistaComponent } from './vistas/administrador/vista/vista.component';
import { ProductoresComponent } from './vistas/administrador/productores/productores.component';
import { PerfilComponent } from './vistas/administrador/perfil/perfil.component';


const routes: Routes = [
      {
        path: 'admin',
        component: AdministradorComponent,
        children: [
        {
      	path: 'afiliaciones',
      	component: AfiliacionesComponent
        },
         {
      	path: 'categorias',
      	component: CategoriasComponent
        },
         {
      	path: 'vista',
      	component: VistaComponent
        },
        {
      	path: 'productores',
      	component: ProductoresComponent
        },
         {
      	path: 'perfil',
      	component: PerfilComponent
        }
        ]
      },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

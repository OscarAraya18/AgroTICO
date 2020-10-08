import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';
import { AfiliacionesComponent } from './vistas/administrador/afiliaciones/afiliaciones.component';
import { CategoriasComponent } from './vistas/administrador/categorias/categorias.component';
import { VistaComponent } from './vistas/administrador/vista/vista.component';
import { ProductoresComponent } from './vistas/administrador/productores/productores.component';
import { PerfilComponent } from './vistas/administrador/perfil/perfil.component';
import { InicioComponent } from './vistas/publicoGeneral/inicio/inicio.component';
import { LoginComponent } from './vistas/publicoGeneral/login/login.component';
import { CrearCuentaComponent } from './vistas/publicoGeneral/crear-cuenta/crear-cuenta.component';
import { ClienteContenidoComponent } from './vistas/publicoGeneral/cliente-contenido/cliente-contenido.component';
import { ListaProductoresComponent} from './vistas/publicoGeneral/lista-productores/lista-productores.component';
import { ListaProductosComponent} from './vistas/publicoGeneral/lista-productos/lista-productos.component';
import { CarritoComprasComponent} from './vistas/publicoGeneral/carrito-compras/carrito-compras.component';
import { ActualizarCuentaComponent } from './vistas/publicoGeneral/actualizar-cuenta/actualizar-cuenta.component';
import { ComprobanteCompraComponent } from './vistas/publicoGeneral/comprobante-compra/comprobante-compra.component';


const routes: Routes = [
      //This is the default route
      //You can change it if you want
      {
        path: '',redirectTo: '/cliente-inicio/login',
         pathMatch: 'full'},
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

      {
        path: 'cliente-inicio',
        component: InicioComponent,
        children:[
        {path: 'login', component: LoginComponent},
        {path: 'crear-cuenta', component: CrearCuentaComponent}
       ]},

       { path: 'cliente-contenido', component: ClienteContenidoComponent,
         children:[
         {path: 'lista-productores/:usuario', component: ListaProductoresComponent},
         {path: 'lista-productos/:idProductor', component: ListaProductosComponent},
         {path: 'carrito-compras', component: CarritoComprasComponent,
        children:[
        {path: 'comprobante', component: ComprobanteCompraComponent}
         ]},
         {path: 'actualizar-cuenta', component: ActualizarCuentaComponent}
       ]}
   //TODO: ADD PAGE NOT FOUND COMPONENT
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

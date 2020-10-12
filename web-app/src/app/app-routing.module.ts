import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';
import { AfiliacionesComponent } from './vistas/administrador/afiliaciones/afiliaciones.component';
import { CategoriasComponent } from './vistas/administrador/categorias/categorias.component';
import { VistaComponent } from './vistas/administrador/vista/vista.component';
import { ProductoresComponent } from './vistas/administrador/productores/productores.component';
import { InicioComponent } from './vistas/publicoGeneral/inicio/inicio.component';
import { LoginComponent } from './vistas/publicoGeneral/login/login.component';
import { CrearCuentaComponent } from './vistas/publicoGeneral/crear-cuenta/crear-cuenta.component';
import { ClienteContenidoComponent } from './vistas/publicoGeneral/cliente-contenido/cliente-contenido.component';
import { ListaProductoresComponent} from './vistas/publicoGeneral/lista-productores/lista-productores.component';
import { ListaProductosComponent} from './vistas/publicoGeneral/lista-productos/lista-productos.component';
import { CarritoComprasComponent} from './vistas/publicoGeneral/carrito-compras/carrito-compras.component';
import { ActualizarCuentaComponent } from './vistas/publicoGeneral/actualizar-cuenta/actualizar-cuenta.component';
import { ComprobanteCompraComponent } from './vistas/publicoGeneral/comprobante-compra/comprobante-compra.component';

import { ProductorComponent } from './vistas/productor/productor.component';
import { AfiliacionComponent } from './vistas/productor/afiliacion/afiliacion.component';
import { ProductosComponent } from './vistas/productor/productos/productos.component';
import { PedidosComponent } from './vistas/productor/pedidos/pedidos.component';
import { FormComponent } from './vistas/productor/afiliacion/form/form.component';
import { EstadoComponent } from './vistas/productor/afiliacion/estado/estado.component';

const routes: Routes = [
     //VISTA ADMINISTRACION
      {
        path: '', redirectTo: '/cliente-inicio/login',
         pathMatch: 'full'
      },
      {
        path: 'form',
        component: FormComponent
      },
      {
        path: 'estado',
        component: EstadoComponent
      },
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
        }
        ]
      },

      //VISTA PÚBLICO GENERAL

      {
        path: 'cliente-inicio',
        component: InicioComponent,
        children: [
        {path: 'login', component: LoginComponent},
        {path: 'crear-cuenta', component: CrearCuentaComponent}
       ]},

       { path: 'cliente-contenido', component: ClienteContenidoComponent,
         children: [
         {path: 'lista-productores/:usuario', component: ListaProductoresComponent},
         {path: 'lista-productos/:idProductor', component: ListaProductosComponent},
         {path: 'carrito-compras', component: CarritoComprasComponent,
        children:[
        {path: 'comprobante', component: ComprobanteCompraComponent}
         ]},
         {path: 'actualizar-cuenta', component: ActualizarCuentaComponent}
       ]},

       //VISTA PRODUCTOR
      {
        path: 'productor',
        component: ProductorComponent,
        children: [
        {
        path: 'afiliacion',
        component: AfiliacionComponent
        },
         {
        path: 'pedidos',
        component: PedidosComponent
        },
         {
        path: 'productos/:id',
        component: ProductosComponent
        }
        ]
      }
   // TODO: ADD PAGE NOT FOUND COMPONENT
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

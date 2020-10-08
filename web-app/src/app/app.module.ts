import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';

import { PerfilComponent } from './vistas/administrador/perfil/perfil.component';
import { VistaComponent } from './vistas/administrador/vista/vista.component';
import { ProductoresComponent } from './vistas/administrador/productores/productores.component';
import { CategoriasComponent } from './vistas/administrador/categorias/categorias.component';
import { AfiliacionesComponent } from './vistas/administrador/afiliaciones/afiliaciones.component';
import { InicioComponent } from './vistas/publicoGeneral/inicio/inicio.component';
import { LoginComponent } from './vistas/publicoGeneral/login/login.component';
import { CrearCuentaComponent } from './vistas/publicoGeneral/crear-cuenta/crear-cuenta.component';
import { ClienteContenidoComponent } from './vistas/publicoGeneral/cliente-contenido/cliente-contenido.component';
import { ListaProductoresComponent } from './vistas/publicoGeneral/lista-productores/lista-productores.component';
import { CarritoComprasComponent } from './vistas/publicoGeneral/carrito-compras/carrito-compras.component';
import { TarjetaProductorComponent } from './vistas/publicoGeneral/tarjeta-productor/tarjeta-productor.component';
import { TarjetaProductoComponent } from './vistas/publicoGeneral/tarjeta-producto/tarjeta-producto.component';
import { ArticuloCarritoComponent } from './vistas/publicoGeneral/articulo-carrito/articulo-carrito.component';
import { ListaProductosComponent } from './vistas/publicoGeneral/lista-productos/lista-productos.component';
import { ActualizarCuentaComponent } from './vistas/publicoGeneral/actualizar-cuenta/actualizar-cuenta.component';
import { ComprobanteCompraComponent } from './vistas/publicoGeneral/comprobante-compra/comprobante-compra.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { ProductorComponent } from './vistas/productor/productor.component';
import { AfiliacionComponent } from './vistas/productor/afiliacion/afiliacion.component';
import { ProductosComponent } from './vistas/productor/productos/productos.component';
import { PedidosComponent } from './vistas/productor/pedidos/pedidos.component';
import { FormComponent } from './vistas/productor/afiliacion/form/form.component';




@NgModule({
  declarations: [
    AppComponent,
    AdministradorComponent,
    PerfilComponent,
    VistaComponent,
    ProductoresComponent,
    CategoriasComponent,
    AfiliacionesComponent,
    InicioComponent,
    LoginComponent,
    CrearCuentaComponent,
    ClienteContenidoComponent,
    ListaProductoresComponent,
    CarritoComprasComponent,
    TarjetaProductorComponent,
    TarjetaProductoComponent,
    ArticuloCarritoComponent,
    ListaProductosComponent,
    ActualizarCuentaComponent,
    ComprobanteCompraComponent,
    ProductorComponent,
    AfiliacionComponent,
    ProductosComponent,
    PedidosComponent,
    FormComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    FormsModule,
    HttpClientModule,
    MatTableModule,
    MatCardModule
    PdfViewerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

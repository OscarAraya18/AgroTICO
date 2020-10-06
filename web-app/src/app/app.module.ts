import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { HttpClientModule} from '@angular/common/http';

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
    ListaProductosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

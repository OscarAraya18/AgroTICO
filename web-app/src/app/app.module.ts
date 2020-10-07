import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdministradorComponent } from './vistas/administrador/administrador.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

import { PerfilComponent } from './vistas/administrador/perfil/perfil.component';
import { VistaComponent } from './vistas/administrador/vista/vista.component';
import { ProductoresComponent } from './vistas/administrador/productores/productores.component';
import { CategoriasComponent } from './vistas/administrador/categorias/categorias.component';
import { AfiliacionesComponent } from './vistas/administrador/afiliaciones/afiliaciones.component'; 

@NgModule({
  declarations: [
    AppComponent,
    AdministradorComponent,
    PerfilComponent,
    VistaComponent,
    ProductoresComponent,
    CategoriasComponent,
    AfiliacionesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

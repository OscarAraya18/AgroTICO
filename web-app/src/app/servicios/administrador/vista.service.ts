import { Injectable } from '@angular/core';
import { Producto } from 'src/app/modelos/productor/producto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioRegistro } from 'src/app/modelos/publicoGeneral/usuario-registro';


@Injectable({
  providedIn: 'root'
})
export class VistaService {

 constructor(private http: HttpClient) { }

  getMasVendidos(): Observable<Producto[]>{
    return this.http.get<Producto[]>('api/Administrador/Productos/masVendidos');
}
 getMasGanancias(): Observable<Producto[]>{
    return this.http.get<Producto[]>('api/Administrador/Productos/masGanancia');
}
getClientes(): Observable<UsuarioRegistro[]>{
    return this.http.get<UsuarioRegistro[]>('api/Administrador/Clientes/masCompras');
}

getMasVendidosProductor(id: number): Observable<Producto[]>{
    return this.http.get<Producto[]>('api/Administrador/Productos/masVendidosProductor', {
      params: {
        cedula: id.toString()
      }});
}
}

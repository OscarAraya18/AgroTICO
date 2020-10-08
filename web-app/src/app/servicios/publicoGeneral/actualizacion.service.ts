import { Injectable } from '@angular/core';
import { UsuarioRegistro } from '../../modelos/publicoGeneral/usuario-registro';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActualizacionService {



  constructor(private http: HttpClient) {}


   getDatosCliente(usuario: string): Observable<UsuarioRegistro>{
    return this.http.get<UsuarioRegistro>('/api/Clientes/MiInfo', {
      params: {
        usuario: usuario
      }});
  }

  actualizarCuenta(usuarioRegistro: UsuarioRegistro){
    return this.http.put<string>('/api/Clientes/edit', usuarioRegistro);
  }

  eliminarCuenta(usuario:string){
    return this.http.delete<string>('/api/Clientes/delete?', {
      params: {
        usuario: usuario
      }});
  }

}

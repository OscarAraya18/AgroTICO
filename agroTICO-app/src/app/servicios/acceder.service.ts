import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioLog } from 'src/app/modelos/usuario-log';
import { UsuarioReg } from 'src/app/modelos/usuario-reg';
import { Compra } from '../modelos/compra';
import { from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccederService {

  constructor(private http: HttpClient) {
   }

   enrollCrearCuenta(usuario: UsuarioReg){
    return this.http.post<string>('/api/Clientes/new', usuario);
  }

  enrollLogin(usuario: UsuarioLog){
    return this.http.post<string>('/api/Clientes/login', usuario);
  }

  enrollCompra(compra: Compra){
    return this.http.post<string>('/api/Clientes/compra', compra);
  }

  getDatosCliente(usuario: string): Observable<UsuarioReg>{
    return this.http.get<UsuarioReg>('/api/Clientes/MiInfo', {
      params: {
        usuario: usuario
      }});
  }

  actualizarCuenta(usuarioRegistro: UsuarioReg){
    return this.http.put<string>('/api/Clientes/edit', usuarioRegistro);
  }

  eliminarCuenta(usuario:string){
    return this.http.delete<string>('/api/Clientes/delete?', {
      params: {
        usuario: usuario
      }});
  }

}

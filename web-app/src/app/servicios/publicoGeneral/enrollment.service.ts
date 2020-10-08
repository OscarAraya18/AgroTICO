import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioRegistro } from '../../modelos/publicoGeneral/usuario-registro';
import { fromEventPattern } from 'rxjs';
import { UsuarioLogin } from 'src/app/modelos/publicoGeneral/usuario-login';
import { Compra } from 'src/app/modelos/publicoGeneral/compra';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  constructor(private http: HttpClient) { }

  
  enrollCrearCuenta(usuario: UsuarioRegistro){
    return this.http.post<string>('/api/Clientes/new', usuario);
  }

  enrollLogin(usuario: UsuarioLogin){
    return this.http.post<string>('/api/Clientes/login', usuario);
  }

  enrollCompra(compra: Compra){
    return this.http.post<string>('/api/Clientes/compra', compra);
  }
}

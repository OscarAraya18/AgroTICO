import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { UsuarioRegistro } from '../../modelos/publicoGeneral/usuario-registro'
import { fromEventPattern } from 'rxjs';
import { UsuarioLogin } from 'src/app/modelos/publicoGeneral/usuario-login';
@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  constructor(private http: HttpClient) { }

  //The post method returns a response as observable
  enrollCrearCuenta(usuario: UsuarioRegistro){
    return this.http.post<any>('', usuario);
  }

  enrollLogin(usuario: UsuarioLogin){
    return this.http.post<any>('', usuario);
  }
}

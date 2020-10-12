import { Injectable } from '@angular/core';
import { ProductorLogIn } from 'src/app/modelos/productor/productor-log-in';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductorLogInService {
idUsuario: number;

  constructor(private http: HttpClient) { }

   login(productor: ProductorLogIn){
    return this.http.post<string>('/api/Productores/login', productor);
  }
  setidUsuario(idUsuario: number){
    this.idUsuario = idUsuario;
    
  }

  getidUsuario(): number{
    return this.idUsuario;
  }
  logOut(){
    this.idUsuario = null;
   
  }
}


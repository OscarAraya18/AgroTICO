import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClienteInfoService {

  nombreUsuario: string = '';
  active: boolean = false;
  constructor() { }

  setNombreUsuario(nombreUsuario: string){
    this.nombreUsuario = nombreUsuario;
    this.active = true;
  }

  getNombreUsuario(): string{
    return this.nombreUsuario;
  }

  getActive():boolean{
    return this.active;
  }
  
  logOut(){
    this.nombreUsuario = '';
    this.active = false;
  }
}

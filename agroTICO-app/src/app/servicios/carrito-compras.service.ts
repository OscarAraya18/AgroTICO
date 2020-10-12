import { Injectable } from '@angular/core';
import { Articulo } from 'src/app/modelos/articulo';
import { UsuarioConfigService } from 'src/app/servicios/usuario-config.service';

@Injectable({
  providedIn: 'root'
})
export class CarritoComprasService {

  montoTotal: number = 0;

  articulosCarrito: Articulo[] = [];

  pdfSrc = '';


  constructor(private usuarioConfig: UsuarioConfigService) { }
  getArticulosCarrito(): Articulo[]{
    return this.articulosCarrito;
  }



  updateMontoTotal(){
    let montoNuevo = 0;
    for(let articulo of this.articulosCarrito){
        montoNuevo += articulo.precioTotal;
    }
    this.montoTotal = montoNuevo;
  }

  getMontoTotal(): number{
    return this.montoTotal;
  }

  updateArticuloTotal(id: number, action: number){
    for(let articulo of this.articulosCarrito){
      if(id === articulo.id){
        if(action === 1 && articulo.disponibilidad > articulo.cantidad){
          articulo.cantidad += 1;
          articulo.precioTotal = articulo.cantidad * articulo.precioUnidad;
          this.updateMontoTotal();
        }
        else{
          if(action === 2 && articulo.cantidad > 0){
            articulo.cantidad -= 1;
            articulo.precioTotal = articulo.cantidad * articulo.precioUnidad;
            this.updateMontoTotal();
          }
        }
        break;
      }
    }
  }

  removeArticulo(articulo: Articulo){
    let index = this.articulosCarrito.indexOf(articulo);
    if (index > -1) {
      this.articulosCarrito.splice(index, 1);
      this.updateMontoTotal();
    }
  }
  onCart(articuloId:number):boolean{
    for(let articulo of this.articulosCarrito){
      if(articuloId === articulo.id){
        return true;
      }
    }
    return false;
  }

  addArticulo(nombre:string, disponibilidad:number, precioUnidad:number, id:number, foto:string){
    //check if the new item already exist on the shopping cart
    if(this.onCart(id)){
      for(let articulo of this.articulosCarrito){
        if(id === articulo.id){
          this.updateArticuloTotal(id, 1);
          this.updateMontoTotal();
        }
      }
    }
    //does not exist on the cart
    else{
      this.articulosCarrito.push(new Articulo(nombre, 1, disponibilidad, precioUnidad, id, foto));
      this.updateMontoTotal();
    }
  }

  reset(){
    this.articulosCarrito = [];
    this.montoTotal = 0;
  }

}

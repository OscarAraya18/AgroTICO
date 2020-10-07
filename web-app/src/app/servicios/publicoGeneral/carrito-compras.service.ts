import { Injectable } from '@angular/core';
import { Articulo } from '../../modelos/publicoGeneral/articulo';

@Injectable({
  providedIn: 'root'
})
export class CarritoComprasService {

  montoTotal: number = 0;

  articulosCarrito: Articulo[] = [];
  constructor() { }
  
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
    console.log(id);
    for(let articulo of this.articulosCarrito){
      if(id === articulo.id){
        if(action === 1){
          articulo.cantidad += 1;
          articulo.precioTotal = articulo.cantidad * articulo.precioUnidad;
          this.updateMontoTotal();
        }
        else{
          if(articulo.cantidad > 0){
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
    }

  }


}

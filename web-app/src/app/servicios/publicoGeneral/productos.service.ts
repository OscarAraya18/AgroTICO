import { Injectable } from '@angular/core';
import { Producto } from '../../modelos/publicoGeneral/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  productos: Producto[] = [
    new Producto("assets/fresas.png", "papas", "Papas muy frescas traidas desde las montañas de vistalmar", 10, 4500, 67),
    new Producto("assets/fresas.png", "rábanos", "Los rábanos son cosechados en la finca de Manuel", 30, 3450, 78),
    new Producto("assets/fresas.png", "pepinos", "Los pepinos son cosechados en la finca de Manuel", 6, 7000, 79),
    new Producto("assets/fresas.png", "tomates", "Los tomates son cosechados en la finca de Manuel", 11, 8000, 80),
    new Producto("assets/fresas.png", "brócoli", "La brócoli es cosechada en la finca de Manuel", 4, 3500, 65)
  ]
  constructor() { }

  getProductos(): Producto[]{
    return this.productos;
  }
}
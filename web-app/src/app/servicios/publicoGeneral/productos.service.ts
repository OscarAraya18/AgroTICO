import { Injectable } from '@angular/core';
import { Producto } from '../../modelos/publicoGeneral/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  productos: Producto[] = [
    new Producto("assets/fresas.png", "papas", "Papas muy frescas traidas desde las montañas de vistalmar", 134, 4500),
    new Producto("assets/fresas.png", "rábanos", "Los rábanos son cosechados en la finca de Manuel", 34, 3450),
    new Producto("assets/fresas.png", "pepinos", "Los pepinos son cosechados en la finca de Manuel", 67, 7000),
    new Producto("assets/fresas.png", "tomates", "Los tomates son cosechados en la finca de Manuel", 12, 8000),
    new Producto("assets/fresas.png", "brócoli", "La brócoli es cosechada en la finca de Manuel", 3, 3500)
  ]
  constructor() { }

  getProductos(): Producto[]{
    return this.productos;
  }
}
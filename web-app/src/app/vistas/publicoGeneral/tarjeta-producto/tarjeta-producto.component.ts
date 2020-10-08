import { Component, Input, OnInit } from '@angular/core';
import { CarritoComprasService } from 'src/app/servicios/publicoGeneral/carrito-compras.service';
import { ProductoI } from 'src/app/modelos/publicoGeneral/producto';
import { Articulo } from 'src/app/modelos/publicoGeneral/articulo';

@Component({
  selector: 'app-tarjeta-producto',
  templateUrl: './tarjeta-producto.component.html',
  styleUrls: ['./tarjeta-producto.component.css']
})
export class TarjetaProductoComponent implements OnInit {

  @Input() productoInfo: ProductoI;

  constructor(private carritoComprasService: CarritoComprasService) { }

  ngOnInit(): void {
  
  }
  addToCarrito(){
    this.carritoComprasService.addArticulo(this.productoInfo.nombre, this.productoInfo.disponibilidad, this.productoInfo.precio, this.productoInfo.codigo, this.productoInfo.foto);
    }

}

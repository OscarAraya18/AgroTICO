import { Component, OnInit } from '@angular/core';
import { Articulo } from 'src/app/modelos/publicoGeneral/articulo';
import { CarritoComprasService } from 'src/app/servicios/publicoGeneral/carrito-compras.service';
@Component({
  selector: 'app-carrito-compras',
  templateUrl: './carrito-compras.component.html',
  styleUrls: ['./carrito-compras.component.css']
})
export class CarritoComprasComponent implements OnInit {

  //Shopping cart array
  //TODO: link with API

  articulosCarrito: Articulo[] = [];
  montoTotal: number= 0;

  constructor(private carritoComprasService: CarritoComprasService) {}

  ngOnInit(): void {
    this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
    this.carritoComprasService.updateMontoTotal();
    this.montoTotal = this.carritoComprasService.getMontoTotal();
    
  }

  updateQts(id: number, action: number){
    this.carritoComprasService.updateArticuloTotal(id, action);
    this.montoTotal = this.carritoComprasService.getMontoTotal();
  }

  removeArticulo(articulo: Articulo){
    this.carritoComprasService.removeArticulo(articulo);
    this.montoTotal = this.carritoComprasService.getMontoTotal();
  }
  


}

import { Component, OnInit } from '@angular/core';
import { Articulo } from 'src/app/modelos/publicoGeneral/articulo';
import { CarritoComprasService } from 'src/app/servicios/publicoGeneral/carrito-compras.service';
import { Compra } from 'src/app/modelos/publicoGeneral/compra';
import { ProductoCompra } from 'src/app/modelos/publicoGeneral/producto-compra';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-carrito-compras',
  templateUrl: './carrito-compras.component.html',
  styleUrls: ['./carrito-compras.component.css']
})
export class CarritoComprasComponent implements OnInit {

  //Shopping cart array
  clienteCompra = new Compra('', '', null, '', null, [])

  articulosCarrito: Articulo[] = [];
  montoTotal: number= 0;
  nombreUsuario = '';

  constructor(private carritoComprasService: CarritoComprasService, public datepipe: DatePipe) {}

  ngOnInit(): void {
    this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
    this.carritoComprasService.updateMontoTotal();
    this.montoTotal = this.carritoComprasService.getMontoTotal();
    this.nombreUsuario = this.carritoComprasService.getNombreUsuario();
    
  }

  updateQts(id: number, action: number){
    this.carritoComprasService.updateArticuloTotal(id, action);
    this.montoTotal = this.carritoComprasService.getMontoTotal();
  }

  removeArticulo(articulo: Articulo){
    this.carritoComprasService.removeArticulo(articulo);
    this.montoTotal = this.carritoComprasService.getMontoTotal();
  }

  buyProducts(){
    //save the total cost
    this.clienteCompra.montoTotal = this.montoTotal;
    //save the user name on the post object
    this.clienteCompra.nombreUsuario = this.nombreUsuario;
    //create the products array
    let productos: ProductoCompra[] = [];

    for(let articulo of this.articulosCarrito){
      productos.push(new ProductoCompra(articulo.id, articulo.cantidad));
    }
    //put the products list
    this.clienteCompra.productos = productos;

    //put the actual date
    let date=new Date();
    this.clienteCompra.fechaCompra =this.datepipe.transform(date, 'yyyy-MM-dd');
    console.log(this.clienteCompra);
    

  }
  


}

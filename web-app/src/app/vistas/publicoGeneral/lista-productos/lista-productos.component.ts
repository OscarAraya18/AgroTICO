import { Component, OnInit } from '@angular/core';
import { ProductosService } from 'src/app/servicios/publicoGeneral/productos.service';
import { Producto } from 'src/app/modelos/publicoGeneral/producto';

@Component({
  selector: 'app-lista-productos',
  templateUrl: './lista-productos.component.html',
  styleUrls: ['./lista-productos.component.css']
})
export class ListaProductosComponent implements OnInit {


  productosLista: Producto[] = [];
  
  constructor(private productos: ProductosService) { }

  ngOnInit(): void {
    this.productosLista = this.productos.getProductos();
  }
}

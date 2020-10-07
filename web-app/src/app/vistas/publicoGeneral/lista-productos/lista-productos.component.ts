import { Component, OnInit } from '@angular/core';
import { ProductosService } from 'src/app/servicios/publicoGeneral/productos.service';
import { ProductoI } from 'src/app/modelos/publicoGeneral/producto';

@Component({
  selector: 'app-lista-productos',
  templateUrl: './lista-productos.component.html',
  styleUrls: ['./lista-productos.component.css']
})
export class ListaProductosComponent implements OnInit {


  productosLista = [];
  
  constructor(private productosService: ProductosService) { }

  ngOnInit(): void {
    this.getProductosById(117770329);

    for(let producto of this.productosLista){
      console.log(producto.nombre)
    }
  }

    //Get products list by productor id
    getProductosById(idProductor: number){

      this.productosService.getProductosByProductorId(idProductor.toString())
      .subscribe(data => this.productosLista = data );
    }
}

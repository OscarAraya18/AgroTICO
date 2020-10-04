import { Component, Input, OnInit } from '@angular/core';
import { Producto } from 'src/app/modelos/publicoGeneral/producto';

@Component({
  selector: 'app-tarjeta-producto',
  templateUrl: './tarjeta-producto.component.html',
  styleUrls: ['./tarjeta-producto.component.css']
})
export class TarjetaProductoComponent implements OnInit {

  @Input() productoInfo: Producto;
  constructor() { }

  ngOnInit(): void {
  }

}

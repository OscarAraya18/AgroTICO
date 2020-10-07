import { Component, OnInit } from '@angular/core';
import { ProductosService } from 'src/app/servicios/publicoGeneral/productos.service';
import { ProductoI } from 'src/app/modelos/publicoGeneral/producto';
import { ActivatedRoute, ParamMap} from '@angular/router';

@Component({
  selector: 'app-lista-productos',
  templateUrl: './lista-productos.component.html',
  styleUrls: ['./lista-productos.component.css']
})
export class ListaProductosComponent implements OnInit {


  productosLista = [];
  idProductor: number = 0;
  constructor(private productosService: ProductosService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = parseInt(params.get('idProductor'));
      this.idProductor = id;
    });
    
    this.getProductosById(this.idProductor);
  }

    //Get products list by productor id
    getProductosById(idProductor: number){
      this.productosService.getProductosByProductorId(idProductor.toString())
      .subscribe(data => this.productosLista = data );
    }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ProductosService } from 'src/app/servicios/productos.service';
import {ProductoI } from 'src/app/modelos/producto';
import { UsuarioConfigService} from 'src/app/servicios/usuario-config.service';
import { CarritoComprasService } from 'src/app/servicios/carrito-compras.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.page.html',
  styleUrls: ['./productos.page.scss'],
})
export class ProductosPage implements OnInit {

  constructor(private carritoComprasService: CarritoComprasService, private router: Router, private route: ActivatedRoute, private productosService: ProductosService, private usuarioConfig: UsuarioConfigService) { }

  idProductor = null;
  productosLista: ProductoI[] = [];
  nombreUsuario = '';
  
  ngOnInit() {
    this.nombreUsuario = this.usuarioConfig.nombreUsuario;
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

      gotoProductores(){
        this.router.navigate(['/productores', this.nombreUsuario])
      }

      addToCart(producto: ProductoI){
        this.carritoComprasService.addArticulo(producto.nombre, producto.disponibilidad, producto.precio, producto.codigo, producto.foto);
        }

}

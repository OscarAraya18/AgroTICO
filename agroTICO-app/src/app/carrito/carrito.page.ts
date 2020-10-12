import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { CarritoComprasService } from 'src/app/servicios/carrito-compras.service';
import { Articulo } from '../modelos/articulo';
import { Compra } from '../modelos/compra';
import { ProductoCompra } from '../modelos/producto-compra';
import { AccederService } from '../servicios/acceder.service';
import { UsuarioConfigService } from '../servicios/usuario-config.service';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.page.html',
  styleUrls: ['./carrito.page.scss'],
})
export class CarritoPage implements OnInit {

    //Shopping cart array
    clienteCompra = new Compra('', '', null, '', null, [])

    articulosCarrito: Articulo[] = [];
    montoTotal: number= 0;
    nombreUsuario = '';
    todayString : string = new Date().toDateString();

    saveAs:any;

  constructor(private carritoComprasService: CarritoComprasService,  private accederService: AccederService, private route: ActivatedRoute, private router: Router, private UsuarioConfig: UsuarioConfigService) { }

  ngOnInit() {
    this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
    this.carritoComprasService.updateMontoTotal();
    this.montoTotal = this.carritoComprasService.getMontoTotal();
    this.nombreUsuario = this.UsuarioConfig.nombreUsuario;
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
    this.clienteCompra.nombreUsuario = this.UsuarioConfig.nombreUsuario;
    //create the products array
    let productos: ProductoCompra[] = [];

    for(let articulo of this.articulosCarrito){
      productos.push(new ProductoCompra(articulo.id, articulo.cantidad));
    }
    //put the products list
    this.clienteCompra.productos = productos;

    //put the actual date
    this.clienteCompra.fechaCompra = this.todayString;

    //pass the object
    this.accederService.enrollCompra(this.clienteCompra)
    .subscribe(
      data => {
        this.clienteCompra = new Compra(this.nombreUsuario, this.todayString, null, '', null, []);
        this.carritoComprasService.reset();
        this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
        this.montoTotal = this.carritoComprasService.getMontoTotal();

        let byteCharacters = atob(data);

        const byteNumbers = new Array(byteCharacters.length);
          for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
          }

          const byteArray = new Uint8Array(byteNumbers);

        var blob = new Blob([byteArray], {type: 'application/pdf'});
        console.log(blob);
        saveAs(blob, "comprobante.pdf");
        
      },
      error => {
        console.log(error);

      })
    this.carritoComprasService.reset()
    console.log(this.clienteCompra);
    

  }

  dostuff(b64Data){
    const byteCharacters = atob(b64Data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    //const blob = new Blob([byteArray], {type: 'application/pdf'});
    //console.log(blob)
    return byteArray
  }

}

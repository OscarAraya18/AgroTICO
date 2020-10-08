import { Component, OnInit } from '@angular/core';
import { Articulo } from 'src/app/modelos/publicoGeneral/articulo';
import { CarritoComprasService } from 'src/app/servicios/publicoGeneral/carrito-compras.service';
import { Compra } from 'src/app/modelos/publicoGeneral/compra';
import { ProductoCompra } from 'src/app/modelos/publicoGeneral/producto-compra';
import { EnrollmentService} from 'src/app/servicios/publicoGeneral/enrollment.service';
import { Router, ActivatedRoute} from '@angular/router';
import { ClienteInfoService } from 'src/app/servicios/publicoGeneral/cliente-info.service';

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
  todayString : string = new Date().toDateString();

  constructor(private carritoComprasService: CarritoComprasService,  private enrollmentService: EnrollmentService, private route: ActivatedRoute, private router: Router, private clienteInfoService: ClienteInfoService) {}

  ngOnInit(): void {
    this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
    this.carritoComprasService.updateMontoTotal();
    this.montoTotal = this.carritoComprasService.getMontoTotal();
    this.nombreUsuario = this.clienteInfoService.getNombreUsuario();
    
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
    this.clienteCompra.nombreUsuario = this.clienteInfoService.nombreUsuario;
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
    this.enrollmentService.enrollCompra(this.clienteCompra)
    .subscribe(
      data => {
        this.clienteCompra = new Compra(this.nombreUsuario, this.todayString, null, '', null, []);
        this.carritoComprasService.reset();
        this.articulosCarrito = this.carritoComprasService.getArticulosCarrito();
        this.montoTotal = this.carritoComprasService.getMontoTotal();
        
        this.carritoComprasService.pdfSrc = data;
        this.router.navigate(['/cliente-contenido/carrito-compras/comprobante']);
      },
      error => {
        console.log(error);

      })
    this.carritoComprasService.reset()
    console.log(this.clienteCompra);
    

  }
  


}

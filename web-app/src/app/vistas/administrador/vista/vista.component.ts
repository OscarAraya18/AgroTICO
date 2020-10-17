import { Component, OnInit } from '@angular/core';
import { VistaService} from 'src/app/servicios/administrador/vista.service';
import { UsuarioRegistro } from 'src/app/modelos/publicoGeneral/usuario-registro';
import { Producto } from 'src/app/modelos/productor/producto';
import { Afiliacion } from 'src/app/modelos/productor/afiliacion';
import { ProductorLogInService} from 'src/app/servicios/productor/productor-log-in.service';
import { ProductoresService} from 'src/app/servicios/administrador/productores.service';

@Component({
  selector: 'app-vista',
  templateUrl: './vista.component.html',
  styleUrls: ['./vista.component.css']
})
export class VistaComponent implements OnInit {
productos: Producto[];
ganancias: Producto[];
clientes: UsuarioRegistro[];
productores: Producto[];
productoresT: Afiliacion[];
productor= new Afiliacion();
  constructor(private _vistasService: VistaService,private _ProductoresService: ProductoresService) { }

  ngOnInit(): void{
this._vistasService.getMasVendidos()
    .subscribe(data => this.productos = data );
this._vistasService.getMasGanancias()
    .subscribe(data => this.ganancias = data );

this._vistasService.getClientes()
    .subscribe(data => this.clientes = data );
    this._ProductoresService.getProductores().
  subscribe(data => this.productoresT = data,
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });
}
  submit(cedula,productor): void {
console.log(cedula);
this.productor = productor;
this._vistasService.getMasVendidosProductor(cedula)
    .subscribe(data => this.productores = data );
  }

}

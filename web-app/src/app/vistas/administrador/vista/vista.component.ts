import { Component, OnInit } from '@angular/core';
import { VistaService} from 'src/app/servicios/administrador/vista.service';
import { UsuarioRegistro } from 'src/app/modelos/publicoGeneral/usuario-registro';
import { Producto } from 'src/app/modelos/productor/producto';


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

  constructor(private _vistasService: VistaService) { }

  ngOnInit(): void{
this._vistasService.getMasVendidos()
    .subscribe(data => this.productos = data );
this._vistasService.getMasGanancias()
    .subscribe(data => this.ganancias = data );

this._vistasService.getClientes()
    .subscribe(data => this.clientes = data );
}
  submit(cedula): void {
console.log(cedula);
this._vistasService.getMasVendidosProductor(cedula)
    .subscribe(data => this.productores = data );
  }

}

import { Component, OnInit } from '@angular/core';
import { PedidosService } from 'src/app/servicios/productor/pedidos.service';
import { Pedido } from 'src/app/modelos/productor/pedido';
import { ProductorLogInService} from 'src/app/servicios/productor/productor-log-in.service';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
pedidos: Pedido[];
ver: boolean;
codigo: number;
nombre: string;
cant: number;
monto: number;
lugar: string[];
cedula: number;


  constructor(private _PedidossService: PedidosService,private _logInService: ProductorLogInService ) { 
  }

  ngOnInit(): void {
  this.ver = false;
  this.getPedidos(this._logInService.getidUsuario());
}



mostrar(cedula, codigo, nombre, cantidad, monto, lugar): void{
this.codigo = codigo;
this.nombre = nombre;
this.cant = cantidad;
this.ver = true;
this.cedula = cedula;
this.monto = monto;
this.lugar = lugar;
}
listo(numeroCedulaCliente){
this.ver = false;
}

getPedidos(cedula: number){
    this._PedidossService.getPedidos(cedula)
    .subscribe(data => this.pedidos = data );
  }

}

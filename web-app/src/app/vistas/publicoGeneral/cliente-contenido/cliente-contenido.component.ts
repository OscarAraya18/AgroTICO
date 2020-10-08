import { Component, OnInit } from '@angular/core';
import { ClienteInfoService } from 'src/app/servicios/publicoGeneral/cliente-info.service';
import { Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-cliente-contenido',
  templateUrl: './cliente-contenido.component.html',
  styleUrls: ['./cliente-contenido.component.css']
})
export class ClienteContenidoComponent implements OnInit {

  nombreUsuario: string = '';

  constructor(private route: ActivatedRoute, private router: Router, private clienteInfoService: ClienteInfoService) { }

  ngOnInit(): void {
    this.nombreUsuario = this.clienteInfoService.getNombreUsuario();
  }

  gotoProductores(){
    this.router.navigate(['/cliente-contenido/lista-productores', this.nombreUsuario]);
  }

  gotoCarritoCompras(){
    this.router.navigate(['/cliente-contenido/carrito-compras']);
  }

  logOut(){
    this.clienteInfoService.logOut();
    this.router.navigate(['cliente-inicio/login']);
  }


}

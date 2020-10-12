import { Component, OnInit } from '@angular/core';
import { Afiliacion } from 'src/app/modelos/productor/afiliacion';
import { AfiliacionesService} from 'src/app/servicios/administrador/afiliaciones.service';

@Component({
  selector: 'app-afiliaciones',
  templateUrl: './afiliaciones.component.html',
  styleUrls: ['./afiliaciones.component.css']
})
export class AfiliacionesComponent implements OnInit {
productores: Afiliacion[];
denegar: boolean;
afiliacion = new Afiliacion();

  constructor(private _AfiliacionesService: AfiliacionesService) { }

  ngOnInit(): void {
this.denegar = false;
this.getAfiliaciones();
}

  aceptar(cedula): void{
console.log(cedula);
console.log(true);
const f = new Date();
console.log(f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear());


this._AfiliacionesService.getAfiliacion(cedula).
  subscribe(data => this.afiliacion = data,
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });
  this.afiliacion.codigoSolicitud = cedula;
  this.afiliacion.numeroCedula= cedula;
this.afiliacion.estado = 'Aceptado';
this.afiliacion.fechaRespuesta = f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear();
this.afiliacion.motivoDenegacion = "";
this._AfiliacionesService.actualizaAfiliacion(this.afiliacion).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });

this.productores = this.productores.filter((i) => i.numeroCedula !== cedula); // filtramos
  }

  denegado(cedula): void {
  const comentario = prompt('Comentarios');
  if (comentario !== null && comentario !== '') {
    console.log(comentario);
    console.log(false);
    const f = new Date();
	console.log(f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear());
  this._AfiliacionesService.getAfiliacion(cedula).
  subscribe(data => this.afiliacion = data,
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });

  this.afiliacion.codigoSolicitud = cedula;
  this.afiliacion.numeroCedula= cedula;
this.afiliacion.estado = 'Denegado';
this.afiliacion.fechaRespuesta = f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear();
this.afiliacion.motivoDenegacion = comentario;
this._AfiliacionesService.actualizaAfiliacion(this.afiliacion).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });
	this.productores = this.productores.filter((i) => i.numeroCedula !== cedula); // filtramos


  }
  }


getAfiliaciones(){
    this._AfiliacionesService.getAfiliaciones()
    .subscribe(data => this.productores = data );
  }

}

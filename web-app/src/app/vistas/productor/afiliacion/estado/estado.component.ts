import { Component, OnInit } from '@angular/core';
import { Afiliacion } from 'src/app/modelos/productor/afiliacion';
import { AfiliacionesService} from 'src/app/servicios/administrador/afiliaciones.service';

@Component({
  selector: 'app-estado',
  templateUrl: './estado.component.html',
  styleUrls: ['./estado.component.css']
})
export class EstadoComponent implements OnInit {
info: boolean;
afiliacion = new Afiliacion();

  constructor(private _AfiliacionesService: AfiliacionesService) { }

  ngOnInit(): void {
  	this.info = false;
  }

  consulta(id: number){
  	 this._AfiliacionesService.getRespuestaAfiliacion(id).
  subscribe(data => this.afiliacion = data,
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });
  this.info = true;


  }

}

import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoriasService} from 'src/app/servicios/administrador/categorias.service';
import { Categoria } from 'src/app/modelos/productor/categoria';


@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {
formVisibility: boolean;
form2Visibility: boolean;
elimina: boolean
categoria = new Categoria();
  constructor(private httpClient: HttpClient,private _CategoriasService: CategoriasService ) {
this.form2Visibility = false;
this.formVisibility = false;
this.elimina = false;
}

  ngOnInit(): void {
  }

    submit(id, nombre): void  {
this.formVisibility = false;
this.categoria.identificador = id;
this.categoria.nombre = nombre;

this._CategoriasService.creaCategoria(this.categoria).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });

  }

  submit2(id, nombre): void  {
this.form2Visibility = false;
console.log('Actualiza');
this.categoria.identificador = id;
this.categoria.nombre = nombre;

this._CategoriasService.getCategoria(this.categoria).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });

this._CategoriasService.actualizaCategoria(this.categoria).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });


  }
  submit3(id): void  {
const confirmed = window.confirm('¿Seguro que desea eliminar esta categoría?');
if (confirmed) {
this.elimina = false;
console.log('Eliminaa');
 this._CategoriasService.borraCategoria(id).
  subscribe(data => {},
error => {
        console.log(error);
        if (error.status === 400){
          
        }
      });
}

}
}

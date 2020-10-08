import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {
formVisibility: boolean;
form2Visibility: boolean;
elimina: boolean;

  constructor() {
this.form2Visibility = false;
this.formVisibility = false;
this.elimina = false;
}

  ngOnInit(): void {
  }

    submit(id, nombre): void  {
this.formVisibility = false;
console.log(id);
console.log(nombre);

  }

  submit2(id, nombre): void  {
this.form2Visibility = false;
console.log('Actualiza');
console.log(id);
console.log(nombre);


  }
  submit3(id): void  {
const confirmed = window.confirm('¿Seguro que desea eliminar esta categoría?');
if (confirmed) {
this.elimina = false;
console.log('Eliminaa');
console.log(id);
}

}
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
formVisibility: boolean;
form2Visibility: boolean;
elimina: boolean;
categorias: string[];

  constructor() {

this.formVisibility = false;
this.form2Visibility = false;
this.elimina = false;
this.categorias = ['Frutas','Verduras','Legumbres'] ;


  }

  ngOnInit(): void {
  }



  submit(codigo, nombre, modo, categoria, foto): void  {
this.formVisibility = false;
console.log(codigo);
console.log(nombre);
console.log(modo);
console.log(categoria);
console.log(foto);


  }
onFileChanged(event): void {
    const file = event.target.files[0];
    console.log(file);
  }
  submit2(codigo, nombre, modo, categoria, foto): void  {
this.form2Visibility = false;
console.log(codigo);
console.log(nombre);
console.log(modo);
console.log(categoria);
console.log(foto);

  }
  submit3(cedula): void  {
const confirmed = window.confirm('¿Seguro que desea eliminar este producto?');
if (confirmed) {
this.elimina = false;
console.log('Eliminaa');
console.log(cedula);
}


  }

}

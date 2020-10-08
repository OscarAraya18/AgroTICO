import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vista',
  templateUrl: './vista.component.html',
  styleUrls: ['./vista.component.css']
})
export class VistaComponent implements OnInit {
productos: string[];
ganancias: string[];
clientes: string[];
productores: string[];

  constructor() { }

  ngOnInit(): void{
this.productos = ['Fresa','Manzana','Papa','Zanahoria','Cebolla','Chile dulce','Culantro','Limón','Yuca','Platano'];
this.ganancias = ['Papa','Zanahoria','Cebolla','Chile dulce','Culantro','Jocote','Ayote','Camote','Mango','Banano'];
this.clientes = ['ffvf','efsdf','dfedw','fred','red','rfed','reds','red','rfdd','redd'];
this.productores = [];

  }

  submit(cedula): void {
console.log(cedula);
this.productores = ['Pitahaya','Naranja','Cebolla','Chile dulce','Culantro','Jocote','Ayote','Camote','Mango','Banano'];
  }

}

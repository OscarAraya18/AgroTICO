import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-afiliaciones',
  templateUrl: './afiliaciones.component.html',
  styleUrls: ['./afiliaciones.component.css']
})
export class AfiliacionesComponent implements OnInit {
productores: any[];
denegar: boolean;

  constructor() { }

  ngOnInit(): void {
this.denegar = false;
this.productores = [
    {
        "numeroCedula": 12330645,
        "primerNombre": "Kevin",
        "segundoNombre": "Francisco",
        "primerApellido": "Acevedo",
        "segundoApellido": "Rodriguez",
        "provinciaResidencia": "Guanacaste",
        "cantonResidencia": "Santa Cruz",
        "distritoResidencia": "La Palma",
        "numeroTelefono": 83488907,
        "numeroSINPE": 757575,
        "anioNacimiento": 2000,
        "mesNacimiento": 6,
        "diaNacimiento": 20,
        "lugarEntrega": ["Parque central", "Mercado de San Jose"],
        "claveAcceso": "234Hola"
    },

    {
        "numeroCedula": 123,
        "primerNombre": "Albert",
        "segundoNombre": "Francisco",
        "primerApellido": "Acevedo",
        "segundoApellido": "Rodriguez",
        "provinciaResidencia": "Guanacaste",
        "cantonResidencia": "Santa Cruz",
        "distritoResidencia": "La Palma",
        "numeroTelefono": 83488907,
        "numeroSINPE": 757575,
        "anioNacimiento": 2000,
        "mesNacimiento": 6,
        "diaNacimiento": 20,
        "lugarEntrega": ["Parque", "Mercado"],
        "claveAcceso": "234Hola"
    },

    {
        "numeroCedula": 12384,
        "primerNombre": "Karol",
        "segundoNombre": "Francisco",
        "primerApellido": "Acevedo",
        "segundoApellido": "Rodriguez",
        "provinciaResidencia": "Guanacaste",
        "cantonResidencia": "Santa Cruz",
        "distritoResidencia": "La Palma",
        "numeroTelefono": 83488907,
        "numeroSINPE": 757575,
        "anioNacimiento": 2000,
        "mesNacimiento": 6,
        "diaNacimiento": 20,
        "lugarEntrega": ["Parque", "Mercado"],
        "claveAcceso": "234Hola"
    },

    {
        "numeroCedula": 1234,
        "primerNombre": "Saymon",
        "segundoNombre": "Francisco",
        "primerApellido": "Acevedo",
        "segundoApellido": "Rodriguez",
        "provinciaResidencia": "Guanacaste",
        "cantonResidencia": "Santa Cruz",
        "distritoResidencia": "La Palma",
        "numeroTelefono": 83488907,
        "numeroSINPE": 757575,
        "anioNacimiento": 2000,
        "mesNacimiento": 6,
        "diaNacimiento": 20,
        "lugarEntrega": ["Parque", "Mercado"],
        "claveAcceso": "234Hola"
    },

    {
        "numeroCedula": 1235,
        "primerNombre": "Oscar",
        "segundoNombre": "Francisco",
        "primerApellido": "Acevedo",
        "segundoApellido": "Rodriguez",
        "provinciaResidencia": "Guanacaste",
        "cantonResidencia": "Santa Cruz",
        "distritoResidencia": "La Palma",
        "numeroTelefono": 83488907,
        "numeroSINPE": 757575,
        "anioNacimiento": 2000,
        "mesNacimiento": 6,
        "diaNacimiento": 20,
        "lugarEntrega": ["Parque", "Mercado"],
        "claveAcceso": "234Hola"
    }
]  }

  aceptar(cedula): void{
console.log(cedula);
console.log(true);
const f = new Date();
console.log(f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear());
this.productores = this.productores.filter((i) => i.numeroCedula !== cedula); // filtramos
  }

  denegado(cedula): void {
  const comentario = prompt('Comentarios');
  if (comentario !== null && comentario !== '') {
    console.log(comentario);
    console.log(false);
    const f = new Date();
		console.log(f.getDate() + '/' + (f.getMonth() + 1) + '/' + f.getFullYear());
		this.productores = this.productores.filter((i) => i.numeroCedula !== cedula); // filtramos


  }
  }

}

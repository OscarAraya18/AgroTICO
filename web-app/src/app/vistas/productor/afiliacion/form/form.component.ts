import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {provincias: string[];
cantones: string[];
distritos: string[];
formVisibility: boolean;
form2Visibility: boolean;
elimina: boolean;

provinciasSeleccion = {
    Alajuela: ['Alajuela', 'San Ramón','Grecia','San Mateo','Atenas','Naranjo','Palmares','Poás','San Pedro',
    'Orotina','Quesada','Zarcero','Sarchí','Upala','Los Chiles','Guatuso','Río Cuarto','San Carlos'],
    'San José': ['San José', 'Escazú','Desamparados','Puriscal','Tarrazú','Aserrí','Mora','Goicoechea',
    'Santa Ana','Alajuelita','Vázquez de Coronado','Acosta','Tibás','Moravia','Montes de Oca','Turrubares',
    'Dota','Curridabat','Pérez Zeledón','León Cortés Castro'],
    Cartago: ['Cartago', 'Alvarado','El Guarco','Jiménez','La Unión','Oreamuno','Paraíso','Turrialba'],
    Heredia:['Heredia','Barva','Belén','Flores','San Isidro','San Pablo','San Rafael','Santa Bárbara',
    'Santo Domingo', 'Sarapiquí'],
    Puntarenas:['Puntarenas','Buenos Aires','Corredores','Coto Brus','Esparza','Garabito','Golfito',
    'Montes de Oro','Osa', 'Parrita','Quepos'],
    Limón:['Limón','Guácimo','Matina','Pococí','Siquirres','Talamanca'],
    Guanacaste:['Liberia','Abangares','Bagaces','Cañas','Carrillo','Hojancha','La Cruz','Nandayure','Nicoya',
    'Santa Cruz', 'Tilarán']
  };

cantonesSeleccion = {
Alajuela: ['Alajuela','San José','Carrizal','San Antonio','Guácima','San Isidro','Tambor','Sabanilla',
'San Rafael','Río Segundo','Desamparados','Turrúcares','La Garita','Sarapiquí'],
'San Ramón':['San Ramón','Santiago','San Juan','Piedades Norte','Piedades Sur','San Rafael','San Isidro',
'Ángeles','Alfaro','Volio','Concepción','Zapotal','Peñas Blancas','San Lorenzo'],
Grecia: ['Grecia','San Isidro','San José','San Roque','Tacares','Puente de Piedra','Bolívar'],
'San Mateo': ['San Mateo','Desmonte','Jesús María','Labrador'],
Atenas: ['Atenas','Jesús','Mercedes','San Isidro','Concepción','San José','Santa Eulalia','Escobal'],
Naranjo: ['Naranjo','San Miguel','San José','Cirrí Sur','San Jerónimo','San Juan','El Rosario','Palmitos'],
Palmares: ['Palmares','Zaragoza','Buenos Aires','Santiago','Candelaria','Esquipulas','La Granja'],
Poás: ['san Pedro','San Juan','San Rafael','Carrillos','Sabana Redonda'],
Orotina: ['Orotina','El Mastate','Hacienda Vieja','Coyolar','La ceiba'],
'San Carlos': ['Quesada','Florencia','Buenavista','Aguas Zarcas','Venecia','Pital','La Fortuna','La Tigra',
'La Palmera', 'Venado','Cutris','Monterrey','Pocosol'],
Zarcero: ['Zarcero','Laguna','Tapesco','Guadalupe','Palmira','Zapote','Brisas'],
Sarchí: ['Sarchí Norte','Sarchí Sur','Toro Amarillo','San Pedro','Rodríguez'],
Upala: ['Upala','Aguas Claras','San José','Bijagua','Delicias','Dos Ríos','Yolillal','Canalete'],
'Los Chiles':['Los chiles','Caño Negro','El Amparo','San Jorge'],
Guatuso: ['San Rafael','Buenavista','Cote','Katira'],
'Río Cuarto': ['Río Cuarto','Santa Isabel','Santa Rita'],
'San José': ['Carmen','Merced','Hospital','Catedral','Zapote','San Francisco de Dos Ríos','La Uruca','Mata Redonda',
'Pavas','Hatillo','San Sebastián'],
Escazú: ['Escazú','San Antonio', 'San Rafael'],
Desamparados: ['Desamparados', 'San Miguel', 'San Juan de Dios', 'San Rafael Arriba','San Antonio','Frailes','Patarrá',
'San Cristóbal','Rosario','Damas','San Rafael Abajo','Gravilias','Los Guidos'],
Puriscal: ['Santiago','Mercedes Sur','Barbacoas','Grifo Alto','San Rafael','Candelaria','Desamparaditos','San Antonio',
'Chires'],
Tarrazú: ['San Marcos','San Lorenzo','San Carlos'],
Aserrí: ['Aserrí','Tarbaca','Vuelta de Jorco','San Gabriel','Legua','Monterrey','Salitrillos'],
Mora: ['Colón', 'Guayabo','Tabarcia','Piedras Negras','Picagres','Jaris','Quitirrisí'],
Goicoechea: ['Guadalupe','San Francisco','Calle Blancos','Mata de Plátano','Ipís','Rancho Redondo','Purral'],
'Santa Ana':['Santa Ana','Salitral','Pozos','Uruca','Piedades','Brasil'],
Alajuelita: ['Alajuelita','San Josecito','San Antonio','Concepción','San Felipe'],
'Vázquez de Coronado':['San Isidro','San Rafael','Dulce Nombre de Jesús','Patalillo','Cascajal'],
Acosta: ['San Ignacio','Guaitil','Palmichal','Cangrejal','Sabanillas'],
Tibás: ['San Juan', 'Cinco Esquinas','Anselmo Llorente','León XIII','Colima'],
Moravia: ['San Vicente','San Jerónimo',"La trinidad"],
'Montes de Oca': ['San Pedro','Sabanilla','Mercedes','San Rafael'],
Turrubares: ['San Pablo','San Pedro','San Juan de Mata','San Luis','Carara'],
Dota: ['Santa María','Jardín','Copey'],
Curridabat: ['Curridabat','Granadilla','Sánchez','Tirrases'],
'Pérez Zeledón': ['San Isidro del General','El General','Daniel Flores','Rivas','San Pedro','Platanares','Pejibaye',
'Cajón','Barú','Río Nuevo','Páramo','La Amistad'],
'León Cortés Castro': ['San Pablo','San Andrés','Llano Bonito', 'San Isidro','Santa Cruz','San Antonio'],
'Cartago': ['Oriental','Occidental','Carmen','San Nicolás','Agua Caliente','Guadalupe','Corralillo','Tierra Blanca',
'Dulce Nombre','Llano Grande', 'Quebradilla'],
Paraíso: ['Paraíso','Santiago','Orosi','Cachí','Llanos de Santa Lucía'],
'La Unión': ['Tres Ríos', 'San Diego','San Juan','San Rafael','Concepción','Dulce Nombre','San Ramón','Río Azul'],
Jiménez: ['Juan Viñas','Tucurrique','Pejibaye'],
Turrialba: ['Turrialba', 'La Suiza', 'Peralta','Santa Cruz','Santa Teresita','Pavones','Tuis','Tayutic','Santa Rosa',
'Tres Equis','La Isabel','Chirripó'],
Alvarado: ['Pacayas','Cervantes','Capellades'],
Oreamuno: ['San Rafael', 'Cot','Potrero Cerrado','Cipreses','Santa Rosa','El Tejar','San Isidro','Tobosi','Patio de Agua'],
Heredia: ['Heredia','Mercedes','San Francisco','Ulloa','Varablanca'],
Barva: ['Barva','San Pedro','San Pablo','San Roque','Santa Lucía','San José de la Montaña'],
'Santo Domingo': ['Santo Domingo','San Vicente','San Miguel','Paracito','Santo Tomás','Santa Rosa','Tures','Pará'],
'Santa Bárbara': ['Santa Bárbara','San Pedro','San Juan','Jesús','Santo Domingo','Purabá'],
'San Rafael': ['San Rafael','San Josecito','Santiago','Ángeles','Concepción'],
'San Isidro': ['San Isidro', 'San José','Concepción','San Francisco'],
Belén: ['San Antonio', 'La Ribera', 'La Asunción'],
Flores: ['San Joaquín', 'Barrantes','Llorente'],
'San Pablo': ['San Pablo','Rincón de Sabanilla'],
'Sarapiquí': ['Puerto Viejo','La Virgen','Horquetas','Llanuras del Gaspar','Cureña'],
'Puntarenas': ['Puntarenas','Pitahaya','Chomes','Lepanto','Paquera','Manzanillo','Guacimal','Barranca','Monte Verde',
'Isla del coco','Cóbano','Chacarita','Chira','Acapulco','El Roble','Arancibia'],
'Esparza': ['Espíritu Santo','San Juan Grande','Macacona','San Rafael','San Jerónimo','Caldera'],
'Buenos Aires': ['Buenos Aires','Volcán','Potrero Grande','Boruca','Pilas','Colinas','Chánguena','Biolley','Brunka'],
'Montes de Oro': ['Miramar','La Unión','San Isidro'],
Osa: ['Puerto Cortés', 'Palmar', 'Sierpe','Bahía Ballena','Piedras Blancas','Bahía Drake'],
Quepos: ['Quepos','Savegre','Naranjito'],
Golfito: ['Golfito','Puerto Jiménez','Guaycará','Pavón'],
'Coto Brus': ['San Vito','Sabalito','Aguabuena','Limoncito','Pittier','Gutiérrez Braun'],
Parrita: ['Parrita'],
Corredores: ['Corredor', 'La Cuesta','Canoas','Laurel','Jacó','Tárcoles'],
Limón: ['Limón','	Valle La Estrella','Río Blanco','Matama'],
Pococí: ['Jiménez','Guápiles','La Rita', 'Roxana','Cariari','Colorado','La Colonia'],
Siquirres: ['Siquirres','Pacuarito','Florida','Germania','El Cairo','Alegría','Reventazón'],
Talamanca: ['Bratsi','Sixaola','Cahuita','Telire'],
Matina: ['Matina','Batán','Carrandi'],
Guácimo: ['Guácimo','Mercedes','Pocora','Río Jiménez','Duacarí'],
Liberia: ['Liberia','Cañas Dulces','Mayorga','Nacascolo','Curubandé'],
Nicoya: ['Nicoya', 'Mansión','San Antonio','Quebrada Honda','Sámara','Nosara','Belén de Nosarita'],
'Santa Cruz': ['Santa Cruz','Bolsón','Veintisiete de Abril','Tempate','Cartagena','Cuajiniquil','Diriá',
'Cabo Velas','Tamarindo'],
Bagaces: ['Bagaces','La Fortuna','Mogote','Río Naranjo'],
Carrillo: ['Filadelfia', 'Palmira','Sardinal','Belén'],
Cañas: ['Cañas', 'Palmira', 'San Miguel','Bebedero','Porozal'],
Abangares: ['Las Juntas','Sierra','San Juan','Colorado'],
Tilarán: ['Tilarán','Quebrada Grande','Tronadora','Santa Rosa','Líbano','Tierras Morenas','Arenal','Cabeceras'],
Nandayure: ['Carmona','	Santa Rita','	Zapotal','San Pablo','Porvenir','Bejuco'],
'La Cruz': ['La Cruz','Santa Cecilia','La Garita', 'Santa Elena'],
Hojancha: ['Hojancha', 'Monte Romo','Puerto Carrillo','Huacas','Matambú']



};

  constructor() {
this.provincias = ['Elegir','Alajuela','San José','Cartago','Heredia','Puntarenas','Limón','Guanacaste'];
  }

  ngOnInit(): void {
  }



  solicitar(cedula, nombre, apellido1, apellido2, provincia, canton, distrito, fecha, numero, sinpe, lugar,contrasena): void  {
console.log(cedula);
console.log(nombre.split(' '));
console.log(apellido1);
console.log(apellido2);
console.log(provincia);
console.log(canton);
console.log(distrito);
console.log('Año: ' + fecha.split('-')[0]);
console.log('Mes: ' + fecha.split('-')[1]);
console.log('Dia: ' + fecha.split('-')[2]);
console.log(numero);
console.log(sinpe);
console.log(lugar.split(','));
console.log(contrasena);

  }

  cambioProvincia(provincia): void  {
this.cantones = this.provinciasSeleccion[provincia];
  }

  cambioCanton(canton): void  {
this.distritos = this.cantonesSeleccion[canton];
  }

}

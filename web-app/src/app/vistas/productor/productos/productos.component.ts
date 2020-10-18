import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap ,  Router} from '@angular/router';
import { CategoriasService } from 'src/app/servicios/administrador/categorias.service';
import { Categoria } from 'src/app/modelos/productor/categoria';
import { ProductosService } from 'src/app/servicios/productor/productos.service';
import { Producto } from 'src/app/modelos/productor/producto';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
formVisibility: boolean;
form2Visibility: boolean;
elimina: boolean;
categorias: Categoria[];
idUsuario: string;
base64img;
producto = new Producto();
productos: Producto[];

constructor(private route: ActivatedRoute, private router: Router, private _CategoriasService: CategoriasService,  private _ProductosService: ProductosService) {

this.formVisibility = false;
this.form2Visibility = false;
this.elimina = false;



  }

  ngOnInit(): void {
     this.route.paramMap.subscribe((params: ParamMap) => {
    let id = params.get('id');
    this.idUsuario = id;
  });

  this.getcategorias();

  this._ProductosService.getProductosProductor(this.idUsuario)
    .subscribe(data => this.productos = data );
}



  submit(codigo, nombre, modo, categoria, disponibilidad, precio): void  {
this.formVisibility = false;
this.producto.codigo = codigo;
this.producto.nombre = nombre;
this.producto.modoVenta = modo;
this.producto.identificadorCategoria = categoria;
this.producto.foto = this.base64img;
this.producto.numeroCedulaProductor = Number(this.idUsuario);
this.producto.disponibilidad = disponibilidad;
this.producto.precio = precio;

this._ProductosService.creaProducto(this.producto)
    .subscribe(data => {} );
    
 this._ProductosService.getProductosProductor(this.idUsuario)
    .subscribe(data => this.productos = data );

  }
onFileChanged(event): void {
  this.readThis(event.target);
  }
  readThis(inputValue: any): void {
  let file : File = inputValue.files[0];
  let  myReader: FileReader = new FileReader();
myReader.readAsDataURL(file);
  myReader.onloadend = (e) => {
    this.base64img = myReader.result;
  }
  
}
  submit2(codigo, nombre, modo, categoria, disponibilidad, precio): void  {
this.form2Visibility = false;
this.producto.codigo = codigo;
this.producto.nombre = nombre;
this.producto.modoVenta = modo;
this.producto.identificadorCategoria = categoria;
this.producto.foto = this.base64img;
this.producto.numeroCedulaProductor = Number(this.idUsuario);
this.producto.disponibilidad = disponibilidad;
this.producto.precio = precio;


this._ProductosService.getProducto(this.producto)
    .subscribe(data => this.producto = data );



this._ProductosService.actualizaProducto(this.producto)
    .subscribe(data => {} );
     this._ProductosService.getProductosProductor(this.idUsuario)
    .subscribe(data => this.productos = data );


  }
  submit3(cod): void  {
const confirmed = window.confirm('¿Seguro que desea eliminar este producto?');
if (confirmed) {
this.elimina = false;

this._ProductosService.borraProducto(cod)
    .subscribe(data => {} );
}
this.productos = this.productos.filter((i) => i.codigo !== cod); // filtramos



  }

  getcategorias(){
    this._CategoriasService.getCategorias()
    .subscribe(data => this.categorias = data );
  }

  actualiza(producto){
    console.log(producto);

  this.producto = producto;
  this.form2Visibility = true;
}

agregar(){
  this.producto = new Producto();
this.formVisibility = true;
}

}

import { Injectable } from '@angular/core';
import { Producto } from '../../modelos/productor/producto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

 constructor(private http: HttpClient) { }

 
 creaProducto( Producto: Producto){
    return this.http.post<string>('/api/Productores/Producto/new', Producto);
  }

   getProducto( Producto: Producto): Observable<Producto>{
    return this.http.get<Producto>('/api/Productores/producto', {
      params: {
        codigo: Producto.codigo.toString()
      }});
}
actualizaProducto( Producto: Producto){
    return this.http.put<string>('/api/Productores/Producto/edit', Producto);
  }
  borraProducto(id: number){
    return this.http.delete<string>('/api/Productores/Producto/delete', {
      params: {
        codigo: id.toString()
      }});
}
}

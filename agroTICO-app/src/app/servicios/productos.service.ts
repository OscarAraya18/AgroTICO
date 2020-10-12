import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { ProductoI } from '../modelos/producto';


@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  constructor(private http: HttpClient) { }
  
  getProductosByProductorId(idProductor: string): Observable<ProductoI[]>{
    return this.http.get<ProductoI[]>('/api/Clientes/Productos/productor?', {
      params: {
        id: idProductor
      }});
  }
}

import { Injectable } from '@angular/core';
import { ProductoI } from '../../modelos/publicoGeneral/producto';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { __param } from 'tslib';

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
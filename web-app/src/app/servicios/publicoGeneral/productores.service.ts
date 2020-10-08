import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductorI } from 'src/app/modelos/publicoGeneral/productor'
import { __param } from 'tslib';


@Injectable({
  providedIn: 'root'
})
export class ProductoresService {

  constructor(private http: HttpClient) { }

  getProductoresPorCanton(usuario: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/canton?', {
      params: {
        usuario: usuario
      }});
  }

  getProductoresPorDistrito(usuario: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/distrito?', {
      params: {
        usuario: usuario
      }});
  }

  getProductoresPorProvincia(usuario: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/provincia?', {
      params: {
        usuario: usuario
      }});
  }

}

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

  getProductoresPorCanton(canton: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/canton?', {
      params: {
        canton: canton
      }});
  }

  getProductoresPorDistrito(distrito: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/distrito?', {
      params: {
        distrito: distrito
      }});
  }

  getProductoresPorProvincia(provincia: string): Observable<ProductorI[]>{
    return this.http.get<ProductorI[]>('/api/Clientes/Productor/provincia?', {
      params: {
        provincia: provincia
      }});
  }

}

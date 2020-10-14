import { Injectable } from '@angular/core';
import { Afiliacion } from 'src/app/modelos/productor/afiliacion';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoresService {

  constructor(private http: HttpClient) { }


   creaProductor(productor: Afiliacion){
    return this.http.post<string>('/api/Administrador/Productor/new', productor);
  }

   getProductor(productor: Afiliacion): Observable<Afiliacion>{
    return this.http.get<Afiliacion>('/api/Administrador/Productor', {
      params: {
        cedula: productor.numeroCedula.toString()
      }});
}
actualizaProductor(productor: Afiliacion){
    return this.http.put<string>('/api/Administrador/Productor/edit', productor);
  }
  borraProductor(id: number){
    return this.http.delete<string>('/api/Administrador/Productor/delete', {
      params: {
        cedula: id.toString()
      }});
}
getProductores(): Observable<Afiliacion[]>{
  return this.http.get<Afiliacion[]>('/api/Administrador/TodosProductores');

}
}

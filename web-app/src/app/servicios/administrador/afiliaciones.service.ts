import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Afiliacion } from '../../modelos/productor/afiliacion';


@Injectable({
  providedIn: 'root'
})
export class AfiliacionesService {

  constructor(private http: HttpClient) { }

  getAfiliaciones(): Observable<Afiliacion[]>{
    return this.http.get<Afiliacion[]>('api/Administrador/Afiliaciones');
}
solicitarAfiliacion(Afiliacion: Afiliacion){
    return this.http.post<string>('/api/Productores/Afiliacion/new', Afiliacion);
  }
  getAfiliacion(id: number): Observable<Afiliacion>{
    return this.http.get<Afiliacion>('api/Administrador/Afiliacion', {
      params: {
        cedula: id.toString()
      }});
}
actualizaAfiliacion(Afiliacion: Afiliacion){
    return this.http.post<string>('/api/Administrador/Afiliacion/edit', Afiliacion);
  }
   getRespuestaAfiliacion(id: number): Observable<Afiliacion>{
    return this.http.get<Afiliacion>('api/Productores/Afiliacion', {
      params: {
        cedula: id.toString()
      }});
}

}

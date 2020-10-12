import { Injectable } from '@angular/core';
import { Categoria } from '../../modelos/productor/categoria';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  getCategorias(): Observable<Categoria[]>{
    return this.http.get<Categoria[]>('/api/Administrador/categorias');
}
 creaCategoria(Categoria: Categoria){
    return this.http.post<string>('/api/Administrador/Categoria/new', Categoria);
  }

   getCategoria(Categoria: Categoria): Observable<Categoria>{
    return this.http.get<Categoria>('/api/Administrador/categoria', {
      params: {
        identificador: Categoria.identificador.toString()
      }});
}
actualizaCategoria(Categoria: Categoria){
    return this.http.put<string>('/api/Administrador/Categoria/edit', Categoria);
  }
  borraCategoria(id: number){
    return this.http.delete<string>('/api/Administrador/Categoria/delete', {
      params: {
        identificador: id.toString()
      }});
}
}

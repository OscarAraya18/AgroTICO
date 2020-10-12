import { Injectable } from '@angular/core';
import { Pedido } from '../../modelos/productor/pedido';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {
constructor(private http: HttpClient) { }

  getPedidos(id: number): Observable<Pedido[]>{
    return this.http.get<Pedido[]>('/api/Productores/pedidos', {
      params: {
        cedula: id.toString()
      }});
}
}

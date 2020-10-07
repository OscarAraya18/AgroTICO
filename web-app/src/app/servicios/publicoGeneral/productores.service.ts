import { Injectable } from '@angular/core';
import { Productor } from '../../modelos/publicoGeneral/productor';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoresService {

  
  //lista de productores

  constructor(private http: HttpClient) { }

  getProductores(): Observable<Productor[]>{
    return this.http.get<Productor[]>("");
  }

}

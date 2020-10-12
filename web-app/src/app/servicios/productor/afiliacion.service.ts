import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Afiliacion } from '../../modelos/productor/afiliacion';

@Injectable({
  providedIn: 'root'
})
export class AfiliacionService {

  constructor(private http: HttpClient) { }


  
}

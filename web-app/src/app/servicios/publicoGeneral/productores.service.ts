import { Injectable } from '@angular/core';
import { Productor } from '../../modelos/publicoGeneral/productor';
@Injectable({
  providedIn: 'root'
})
export class ProductoresService {
  //lista de productores
  productores: Productor[] = [
    new Productor(1, "Kevin Acevedo", "assets/jack.png", "Mis productos son de la zona de Santa Cruz"),
    new Productor(2, "Saymon Astúa", "assets/jack.png", "Mis productos son de la zona de Santa Cruz"),
    new Productor(3, "Oscar Araya", "assets/jack.png", "Mis productos son de la zona de Santa Cruz"),
    new Productor(4, "Diego Noguera", "assets/jack.png", "Mis productos son de la zona de Santa Cruz"),
    new Productor(5, "Abigail Abarca", "assets/jack.png", "Mis productos son de la zona de Santa Cruz"),
  ]
  constructor() { }

  getProductores(): Productor[]{
    return this.productores;
  }

}

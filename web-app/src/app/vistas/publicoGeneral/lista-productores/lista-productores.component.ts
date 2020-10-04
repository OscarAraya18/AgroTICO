import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { ProductoresService } from 'src/app/servicios/publicoGeneral/productores.service';
import { Productor } from 'src/app/modelos/publicoGeneral/productor';

@Component({
  selector: 'app-lista-productores',
  templateUrl: './lista-productores.component.html',
  styleUrls: ['./lista-productores.component.css']
})
export class ListaProductoresComponent implements OnInit {

  productoresLista: Productor[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private productorService: ProductoresService) { }

  ngOnInit(): void {
    this.productoresLista = this.productorService.getProductores();
  }

}

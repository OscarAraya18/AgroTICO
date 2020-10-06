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

  productoresLista = [];

  constructor(private route: ActivatedRoute, private router: Router, private productorService: ProductoresService) { }

  ngOnInit(): void {
    this.productorService.getProductores()
    .subscribe( data => this.productoresLista = data);
  }

}

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { ProductoresService } from 'src/app/servicios/publicoGeneral/productores.service';


@Component({
  selector: 'app-lista-productores',
  templateUrl: './lista-productores.component.html',
  styleUrls: ['./lista-productores.component.css']
})
export class ListaProductoresComponent implements OnInit {

  public productoresLista = [];

  constructor(private route: ActivatedRoute, private router: Router, private productorService: ProductoresService) { }

  ngOnInit(): void {
   this.getProductoresCanton();
    
  }

  //Get productor list from canton
  getProductoresCanton(){
    this.productorService.getProductoresPorCanton('Perez Zeledon')
    .subscribe(data => this.productoresLista = data );
  }

  //Get productor list from distrito
  getProductoresDistrito(){
    this.productorService.getProductoresPorDistrito('Santa Cruz')
    .subscribe(data => this.productoresLista = data );
  }

  //Get productor list from provincia
  getProductoresProvincia(){
    this.productorService.getProductoresPorProvincia('Guanacaste')
    .subscribe(data => this.productoresLista = data );
  }

}

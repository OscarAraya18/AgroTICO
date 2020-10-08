import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap} from '@angular/router';
import { ProductoresService } from 'src/app/servicios/publicoGeneral/productores.service';

@Component({
  selector: 'app-lista-productores',
  templateUrl: './lista-productores.component.html',
  styleUrls: ['./lista-productores.component.css']
})
export class ListaProductoresComponent implements OnInit {

  public productoresLista = [];
  nombreUsuario = ''
  constructor(private route: ActivatedRoute, private router: Router, private productorService: ProductoresService) { }

  ngOnInit(): void {

   this.route.paramMap.subscribe((params: ParamMap) => {
    let usuario = params.get('usuario');
    this.nombreUsuario = usuario;
  
    this.getProductoresCanton();
  });
  
  }

  //Get productor list from canton
  getProductoresCanton(){
    this.productorService.getProductoresPorCanton(this.nombreUsuario)
    .subscribe(data => this.productoresLista = data );
  }

  //Get productor list from distrito
  getProductoresDistrito(){
    this.productorService.getProductoresPorDistrito(this.nombreUsuario)
    .subscribe(data => this.productoresLista = data );
  }

  //Get productor list from provincia
  getProductoresProvincia(){
    this.productorService.getProductoresPorProvincia(this.nombreUsuario)
    .subscribe(data => this.productoresLista = data );
  }

}

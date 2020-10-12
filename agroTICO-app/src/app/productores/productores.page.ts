import { Component, OnInit } from '@angular/core';
import { ProductoresService } from 'src/app/servicios/productores.service';
import { Router, ActivatedRoute, ParamMap} from '@angular/router';

@Component({
  selector: 'app-productores',
  templateUrl: './productores.page.html',
  styleUrls: ['./productores.page.scss'],
})
export class ProductoresPage implements OnInit {

  public productoresLista = [];
  nombreUsuario = '';
  constructor(private route: ActivatedRoute, private router: Router, private productorService: ProductoresService) { }

  ngOnInit() {
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

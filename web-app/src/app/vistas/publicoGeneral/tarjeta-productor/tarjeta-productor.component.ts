import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { ProductorI } from 'src/app/modelos/publicoGeneral/productor';


@Component({
  selector: 'app-tarjeta-productor',
  templateUrl: './tarjeta-productor.component.html',
  styleUrls: ['./tarjeta-productor.component.css']
})
export class TarjetaProductorComponent implements OnInit {

  @Input() productorInfo: ProductorI;
  
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }

  gotoProductList(){
    this.router.navigate(['/cliente-contenido/lista-productos']);
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductorLogInService} from 'src/app/servicios/productor/productor-log-in.service';


@Component({
  selector: 'app-productor',
  templateUrl: './productor.component.html',
  styleUrls: ['./productor.component.css']
})
export class ProductorComponent implements OnInit {
param: number;

  constructor(public route: Router, public _logInService: ProductorLogInService ) { }

  ngOnInit(): void {
  	this.param = this._logInService.getidUsuario();
  }

}

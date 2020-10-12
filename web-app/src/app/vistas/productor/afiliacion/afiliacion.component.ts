import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { ProductorLogIn } from 'src/app/modelos/productor/productor-log-in';
import { ProductorLogInService} from 'src/app/servicios/productor/productor-log-in.service';



@Component({
  selector: 'app-afiliacion',
  templateUrl: './afiliacion.component.html',
  styleUrls: ['./afiliacion.component.css']
})
export class AfiliacionComponent implements OnInit {
invalid = false;

  productor = new ProductorLogIn(0, '' );
  constructor(private route: ActivatedRoute, private router: Router, private _logInService: ProductorLogInService ) { }

  ngOnInit(): void {
  }

  ingresar(cedula, contrasena): void{
  this.productor.numeroCedula = cedula;
  this.productor.claveAcceso = contrasena;
  this._logInService.setidUsuario(cedula);
  this._logInService.login(this.productor).
  subscribe(data => {
console.log(cedula);
console.log(contrasena);
this.invalid = false;
this.router.navigate(['/productor/productos', cedula]);
},
error => {
        console.log(error);
        this.invalid = true;
        if (error.status === 400){
          this.productor.numeroCedula = 0;
          this.productor.claveAcceso = '';
        }

      });

  }

}

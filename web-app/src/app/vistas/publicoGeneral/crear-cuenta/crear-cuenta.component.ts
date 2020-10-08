import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router'
import { UsuarioRegistro } from 'src/app/modelos/publicoGeneral/usuario-registro';
import {EnrollmentService } from 'src/app/servicios/publicoGeneral/enrollment.service'
@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']
})
export class CrearCuentaComponent implements OnInit {

  isCreated:boolean = false;
  userExist:boolean = false;

  constructor(private route: ActivatedRoute, private router: Router, private enrollmentService: EnrollmentService) { }


  usuarioR = new UsuarioRegistro('', '', '', '', null, null, '', '', '', '', '', '');
  ngOnInit(): void {
  }
  gotoLogin(){
    this.router.navigate(['/cliente-inicio/login']);
  }

  onSubmit(){
    this.enrollmentService.enrollCrearCuenta(this.usuarioR)
    .subscribe(
      data => {
        console.log(data);
        //reset the fields
        this.usuarioR = new UsuarioRegistro('', '', '', '', null, null, '', '', '', '', '', '');
        this.isCreated = true;
        this.userExist = false;
        this.gotoLogin();
      },
      error => {
        console.log(error);
        this.isCreated = false;
        if(error.status === 404){
          this.isCreated = false;
          this.userExist = true;
        }
      })

  }

  

}

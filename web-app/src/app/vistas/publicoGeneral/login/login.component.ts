import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { UsuarioLogin } from 'src/app/modelos/publicoGeneral/usuario-login';
import { EnrollmentService} from 'src/app/servicios/publicoGeneral/enrollment.service';
import { ClienteInfoService } from 'src/app/servicios/publicoGeneral/cliente-info.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalid = false;

  usuarioL = new UsuarioLogin('', '');
  constructor(private route: ActivatedRoute, private router: Router, private enrollmentService: EnrollmentService, private clienteInfoService: ClienteInfoService) { }

  ngOnInit(): void {
  }

  gotoContenido(){
    this.router.navigate(['/cliente-contenido/lista-productores', this.usuarioL.nombreUsuario]);
  }

  onSubmit(){
    
    this.enrollmentService.enrollLogin(this.usuarioL)
    .subscribe(
      data => {
        console.log(this.usuarioL.nombreUsuario);
        console.log(data);
        this.invalid = false;
        this.clienteInfoService.setNombreUsuario(this.usuarioL.nombreUsuario);
        this.gotoContenido();

      },
      error => {
        console.log(error);
        this.invalid = true;
        if(error.status === 400){
          this.usuarioL = new UsuarioLogin('', '');
        }
      })
  }


}

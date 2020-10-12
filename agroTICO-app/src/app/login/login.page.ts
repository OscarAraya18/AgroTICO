import { Component, OnInit } from '@angular/core';
import { Router } from  "@angular/router";
import { UsuarioLog } from 'src/app/modelos/usuario-log';
import { AccederService } from 'src/app/servicios/acceder.service';
import { UsuarioConfigService } from 'src/app/servicios/usuario-config.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(private router: Router, private accederService: AccederService, private usuarioConfigService: UsuarioConfigService) { }

  ingresoDenegado = false;
  usuarioL = new UsuarioLog('', '');

  ngOnInit() {
  }

  gotoContenido(){
    this.router.navigate(['/productores', this.usuarioL.nombreUsuario]);
  }



  onSubmit(){
    
    this.accederService.enrollLogin(this.usuarioL)
    .subscribe(
      data => {
        console.log(this.usuarioL.nombreUsuario);
        console.log(data);
        this.ingresoDenegado = false;
        this.usuarioConfigService.nombreUsuario = this.usuarioL.nombreUsuario;
        this.gotoContenido();

      },
      error => {
        console.log(error);
        this.ingresoDenegado = true;
        if(error.status === 400){
          this.usuarioL = new UsuarioLog('', '');
        }
      })
  }
}

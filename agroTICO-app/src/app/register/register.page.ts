import { Component, OnInit } from '@angular/core';
import { Router } from  "@angular/router"; 
import { AccederService } from 'src/app/servicios/acceder.service';
import { UsuarioReg } from 'src/app/modelos/usuario-reg';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  usuarioR = new UsuarioReg('', '', '', '', null, null, '', '', '', '', '', '');
  isCreated:boolean = false;
  userExist:boolean = false;
  constructor(private router: Router, private accederService: AccederService) { }

  ngOnInit() {
  }

  gotoLogin(){
    this.router.navigateByUrl('login');
  }

  onSubmit(){
    this.accederService.enrollCrearCuenta(this.usuarioR)
    .subscribe(
      data => {
        console.log(data);
        //reset the fields
        this.usuarioR = new UsuarioReg('', '', '', '', null, null, '', '', '', '', '', '');
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

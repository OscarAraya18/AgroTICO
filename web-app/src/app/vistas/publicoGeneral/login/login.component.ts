import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { UsuarioLogin } from 'src/app/modelos/publicoGeneral/usuario-login'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuarioL = new UsuarioLogin('', '');
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }

  gotoContenido(){
    this.router.navigate(['/cliente-contenido/lista-productores', this.usuarioL.nombreUsuario]);
  }

  onSubmit(){
    console.log(this.usuarioL);
  }


}

import { Component, OnInit } from '@angular/core';
import { UsuarioRegistro } from 'src/app/modelos/publicoGeneral/usuario-registro';
import { ActualizacionService } from 'src/app/servicios/publicoGeneral/actualizacion.service'
import { ClienteInfoService } from 'src/app/servicios/publicoGeneral/cliente-info.service';
import { Router, ActivatedRoute} from '@angular/router';


@Component({
  selector: 'app-actualizar-cuenta',
  templateUrl: './actualizar-cuenta.component.html',
  styleUrls: ['./actualizar-cuenta.component.css']
})
export class ActualizarCuentaComponent implements OnInit {

  nombreUsuario:string = '';

  usuarioR = new UsuarioRegistro('', '', '', '', null, null, '', '', '', '', '', '');

  isCreated:boolean = false;
  userExist:boolean = false;

  constructor(private actualizacionService: ActualizacionService, private clienteInfoService: ClienteInfoService, private route: ActivatedRoute, private router: Router ) { }

  ngOnInit(): void {
    this.nombreUsuario = this.clienteInfoService.getNombreUsuario();
    this.getDatosUsuario();
    console.log(this.usuarioR);
  }

    //Get productor list from canton
    getDatosUsuario(){
      this.actualizacionService.getDatosCliente(this.nombreUsuario)
      .subscribe(data => this.usuarioR = data);
    
    }

    onSubmit(){
      this.actualizacionService.actualizarCuenta(this.usuarioR)
      .subscribe(
        data => {
          console.log(data);
          //reset the fields
          this.usuarioR = new UsuarioRegistro('', '', '', '', null, null, '', '', '', '', '', '');
          this.userExist = false;
          this.gotoListaProductores();
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

    deleteAccount(){
      this.actualizacionService.eliminarCuenta(this.nombreUsuario)
      .subscribe(
        data => {
          console.log(data);
          //reset the fields
          this.router.navigate(['cliente-inicio/login']);
        },
        error => {
          console.log(error);
          if(error.status === 404){

          }
        })

    }

    gotoListaProductores(){
      this.router.navigate(['/cliente-contenido/lista-productores', this.nombreUsuario]);
    }

}

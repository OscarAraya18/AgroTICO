import { Component, OnInit } from '@angular/core';
import { UsuarioConfigService } from 'src/app/servicios/usuario-config.service';
import { Router, ActivatedRoute} from '@angular/router';
import { UsuarioReg } from 'src/app/modelos/usuario-reg';
import { AccederService } from 'src/app/servicios/acceder.service';

@Component({
  selector: 'app-actualizar',
  templateUrl: './actualizar.page.html',
  styleUrls: ['./actualizar.page.scss'],
})
export class ActualizarPage implements OnInit {

  nombreUsuario:string = '';

  usuarioR = new UsuarioReg('', '', '', '', null, null, '', '', '', '', '', '');

  isCreated:boolean = false;
  userExist:boolean = false;

  constructor(private accederService: AccederService, private clienteInfoService: UsuarioConfigService, private route: ActivatedRoute, private router: Router ) { }

  ngOnInit() {
    this.nombreUsuario = this.clienteInfoService.nombreUsuario;
    this.getDatosUsuario();
    console.log(this.usuarioR);
  }

    //Get productor list from canton
    getDatosUsuario(){
      this.accederService.getDatosCliente(this.nombreUsuario)
      .subscribe(data => this.usuarioR = data);
    
    }

    onSubmit(){
      this.accederService.actualizarCuenta(this.usuarioR)
      .subscribe(
        data => {
          console.log(data);
          //reset the fields
          this.usuarioR = new UsuarioReg('', '', '', '', null, null, '', '', '', '', '', '');
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
      this.accederService.eliminarCuenta(this.nombreUsuario)
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
        this.router.navigate(['productores', this.nombreUsuario]);
      }
}

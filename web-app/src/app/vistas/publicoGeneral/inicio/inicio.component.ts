import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }

  gotoContenido(){
    this.router.navigate(['/tienda']);
  }

  showLogin(){
    this.router.navigate(['login'], {relativeTo: this.route});
  }

  showCrearCuenta(){
    this.router.navigate(['crear-cuenta'], {relativeTo: this.route});
  }

}

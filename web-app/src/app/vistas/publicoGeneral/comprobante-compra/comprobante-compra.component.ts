import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap} from '@angular/router';
import { CarritoComprasService } from 'src/app/servicios/publicoGeneral/carrito-compras.service';
@Component({
  selector: 'app-comprobante-compra',
  templateUrl: './comprobante-compra.component.html',
  styleUrls: ['./comprobante-compra.component.css']
})
export class ComprobanteCompraComponent implements OnInit {
  pdf: any = null;

  constructor(private route: ActivatedRoute, private carritoComprasService: CarritoComprasService) { }

  ngOnInit(): void {
    this.pdf = this.dostuff(this.carritoComprasService.pdfSrc);
  }

  dostuff(b64Data){
    const byteCharacters = atob(b64Data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    //const blob = new Blob([byteArray], {type: 'application/pdf'});
    //console.log(blob)
    return byteArray
  }

}

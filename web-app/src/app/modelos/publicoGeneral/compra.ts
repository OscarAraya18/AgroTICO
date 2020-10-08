import { ProductoCompra } from "./producto-compra";

export class Compra{
    constructor(
        public nombreUsuario: string,
        public fechaCompra: string,
        public calificacionGeneral: number,
        public direccionEntrega: string,
        public montoTotal:number,
        public productos: ProductoCompra[]
    ){}
}
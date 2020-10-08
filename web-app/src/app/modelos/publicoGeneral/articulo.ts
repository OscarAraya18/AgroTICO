export class Articulo {
    nombre: string;
    cantidad: number;
    precioUnidad: number;
    precioTotal: number;
    id: number;
    disponibilidad:number;
    foto:string;

    constructor(nombre, cantidad, disponibilidad, precioUnidad, id, foto, precioTotal = precioUnidad * cantidad){
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.disponibilidad = disponibilidad;
        this.precioUnidad = precioUnidad;
        this.id = id;
        this.foto = foto;
        this.precioTotal = precioTotal;

    }

}

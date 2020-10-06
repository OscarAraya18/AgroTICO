export class Articulo {
    nombre: string;
    cantidad: number;
    precioUnidad: number;
    precioTotal: number;
    id: number;

    constructor(nombre, cantidad, precioUnidad, id, precioTotal = precioUnidad * cantidad){
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.precioUnidad = precioUnidad;
        this.id = id;
        this.precioTotal = precioTotal;

    }

}

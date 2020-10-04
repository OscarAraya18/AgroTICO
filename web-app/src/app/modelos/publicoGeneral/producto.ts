export class Producto {
    imgURL: string;
    nombre: string;
    descripcion: string;
    disponibilidad: number;
    precio: number;

    constructor(imgURL, nombre, descripcion, disponibiliad, precio){
        this.imgURL = imgURL;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.disponibilidad = disponibiliad;
        this.precio = precio;
    }
}

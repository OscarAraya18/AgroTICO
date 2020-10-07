export class Producto {
    imgURL: string;
    nombre: string;
    descripcion: string;
    disponibilidad: number;
    precio: number;
    id: number;

    constructor(imgURL, nombre, descripcion, disponibiliad, precio, id){
        this.imgURL = imgURL;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.disponibilidad = disponibiliad;
        this.precio = precio;
        this.id = id;
    }
}

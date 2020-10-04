export class Productor {
    id: number;
    nombre: string;
    imgURL: string;
    descripcion: string;

    constructor(id, nombre, imgURL, descripcion){
        this.id = id;
        this.nombre = nombre;
        this.imgURL = imgURL;
        this.descripcion = descripcion;
    }
}

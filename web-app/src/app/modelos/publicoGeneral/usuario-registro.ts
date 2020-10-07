export class UsuarioRegistro {
    constructor(
        public nombre: string,
        public primerApellido: string,
        public segundoApellido: string,
        public numeroCedula: number,
        public numeroTelefono: number,
        public provincia: string,
        public canton: string,
        public distrito: string,
        public fechaNacimiento: string,
        public usuario: string,
        public contrasena: string
    ){}
}

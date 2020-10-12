export class UsuarioReg {
    constructor(
        public primerNombre: string,
        public segundoNombre: string,
        public primerApellido: string,
        public segundoApellido: string,
        public numeroCedula: number,
        public numeroTelefono: number,
        public provinciaResidencia: string,
        public cantonResidencia: string,
        public distritoResidencia: string,
        public fechaNacimiento: string,
        public claveAcceso: string,
        public nombreUsuario: string
    ){}
}

export class Operacion {
    /*Requeridas*/
    id:number;
    monto:number;
    Fecha: Date;
    tipo:string;
    id_cuenta:number;


    /*Opcionales*/
    Origen:string;
    Destino:string;
}
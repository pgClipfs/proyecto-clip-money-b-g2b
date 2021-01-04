import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import {Cuenta} from '../models/cuenta.model'

@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  constructor(private http:HttpClient) {
    console.log("Servicio Cuenta esta andando")
   }

  url = "https://localhost:44316/api/cuenta";

  postCuenta(cuenta: Cuenta){
    let header = new HttpHeaders().set('Content-Type','application/json')
    let body = {
      "Num_de_cuenta": cuenta.num_de_cuenta,
      "Tipo_de_cuenta": cuenta.tipo_de_cuenta,
      "Estado_de_cuenta": cuenta.estado_de_cuenta,
      "Saldo": cuenta.saldo,
      "Cbu": cuenta.cbu,
      "Cvu": cuenta.cvu,
      "Id_cliente": cuenta.id_cliente,
    }
    return this.http.post<string>(this.url,body,{headers:header})
  }
}

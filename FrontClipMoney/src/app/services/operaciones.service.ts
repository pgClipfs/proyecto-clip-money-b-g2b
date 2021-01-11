import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { Operacion } from '../models/operacion.model';

@Injectable({
  providedIn: 'root'
})
export class OperacionesService {

  url = "https://localhost:44316/api/operacion";
  constructor(private http:HttpClient) { }

  generar_ingreso(op: Operacion){
    console.log(op)
    let header = new HttpHeaders().set('Content-Type','application/json')
    let body = {
      "Id_cuenta": op.id_cuenta,
	    "Monto": op.monto,
      "Tipo": "Ingreso"
    }
    return this.http.put<string>(this.url,body,{headers:header})

  }
  generar_extraccion(op: Operacion){

    let header = new HttpHeaders().set('Content-Type','application/json')
    let body = {
      "Id_cuenta": op.id_cuenta,
	    "Monto": op.monto,
      "Tipo": "Extraccion"
    }
    return this.http.put<string>(this.url,body,{headers:header})

  }
  ultimos_movimientos(id: number){
    let header = new HttpHeaders().set('Content-Type','application/json')
    let url_get = this.url + "/" + id;
    return this.http.get<Operacion[]>(url_get,{headers:header})
  }
}

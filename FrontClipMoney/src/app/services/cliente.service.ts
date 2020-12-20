import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import {Cliente} from '../models/cliente.model'

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url = "https://localhost:44316/api/cliente";
  constructor(private http:HttpClient ) {
    console.log("Servicio Cliente esta andando")
   }

  getCliente(id: number){
    let header = new HttpHeaders().set('Content-Type','application/json').set('Authorization',localStorage.getItem('token'))
    let url_get = this.url + "/" + id;
    return this.http.get<Cliente>(url_get,{headers:header})

  }

  postCliente(clt: Cliente){
    let header = new HttpHeaders().set('Content-Type','application/json')
    let body = {
      "ID": 0,
      "Nombre": clt.Nombre,
      "Usuario":  clt.Usuario,
      "Apellido": clt.Apellido,
      "Telefono": clt.Telefono,
      "Email": clt.Email,
      "Dni": clt.Dni,
      "Cuil": clt.Cuil,
      "Direccion": clt.Direccion,
      "Nacionalidad": clt.Nacionalidad,
      "Sexo": clt.Sexo,
      "Contraseña": clt.Pass,
      "Sitacion_crediticia": clt.Situacion_crediticia
    }
    return this.http.post<string>(this.url,body,{headers:header})
  }
}

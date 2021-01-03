import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestablecerService {

  url = "https://localhost:44316/api/restablecer";
  constructor(private http:HttpClient) {
    console.log("Servicio Restablecer esta andando")
   }

   cambiar_contraseña(pass:string, token:string, id:number){
    let header = new HttpHeaders().set('Content-Type','application/json').set('Authorization',token);
    let body =
    {
      "ID": id,
      "Contraseña": pass
    }
    return this.http.put<string>(this.url,body,{headers:header})
   }
   enviar_email(email:string){
    let header = new HttpHeaders().set('Content-Type','application/json');
    let body =
    {
      Email: email
    }
    return this.http.post<string>(this.url,body,{headers:header})
   }
}

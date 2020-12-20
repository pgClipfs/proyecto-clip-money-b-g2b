import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url = "https://localhost:44316/api/login/authenticate";
  constructor(private http:HttpClient) { 
    console.log("Servicio Login esta andando")
  }

  login(user:string, pass: string) : Observable<any>{
    let header = new HttpHeaders().set('Content-Type','application/json');
    let body =
    {
      "usuario" : user,
      "contraseña": pass
    }
    return this.http.post<string>(this.url,body,{headers:header})
  }
}

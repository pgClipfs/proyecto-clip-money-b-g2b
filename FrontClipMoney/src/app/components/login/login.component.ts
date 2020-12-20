import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {LoginService} from '../../services/login.service'

import * as CryptoJS from 'crypto-js';
import { environment } from 'src/environments/environment';

declare var M: any;

import Swal from 'sweetalert2'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user_form: string = '';
  pass_form: string = '';
  public okey: string;

  constructor(private loginService: LoginService,private ruta: Router) { 

  }

  ngOnInit(): void {
    
    if (localStorage.getItem("token") != null) {
      this.ruta.navigateByUrl("/clientes")
    }
  }

   login_user(user:string, pass: string){

    var key = CryptoJS.enc.Base64.parse(environment.SECRET_KEY);
    var iv  = CryptoJS.enc.Base64.parse("7781157e2629b094f0e3dd48c4d786115");
    
      this.loginService.login(user, CryptoJS.AES.encrypt(pass.trim(), key,{iv: iv}).toString())
      .subscribe (resp =>{

        if(user=='' || pass=='' ){
          M.toast({html: 'Faltan datos',classes: 'rounded orange accent-2'})
          return;
        }


        if (resp==null) M.toast({html: 'El usuario o contraseña son incorrectos',classes: 'rounded orange accent-2'})
        else{
        localStorage.setItem("token", resp.Token);
        localStorage.setItem("idCliente",resp.ID )

        this.ruta.navigateByUrl("/clientes")
        }
        });
    
  }
  register_redirect(){
    this.ruta.navigateByUrl("/register")
  }
}

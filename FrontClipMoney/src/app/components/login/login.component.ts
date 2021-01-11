import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {LoginService} from '../../services/login.service'
import { RestablecerService } from 'src/app/services/restablecer.service';

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
  email_input: string ='';
  public okey: string;

  constructor(private loginService: LoginService,private ruta: Router,private resService: RestablecerService) { 
    
  }

  ngOnInit(): void {
    
    if (localStorage.getItem("token") != null) {
      this.ruta.navigateByUrl("/clientes")
    }

    document.addEventListener('DOMContentLoaded', function() {
      var elem = document.querySelectorAll('.modal');
      var instances = M.Modal.init(elem, null);
    });
    
  
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
  enviar_email(email: string){
    this.resService.enviar_email(email).subscribe(data => {
      if(data == 'no existe usuario con ese mail'){
        M.toast({html: 'no existe usuario con ese mail',classes: 'rounded orange accent-2'})
          return;
      }
      M.toast({html: 'Email Enviado',classes: 'rounded orange accent-2'})
      var elems = document.getElementById('modal1');
      var instance = M.Modal.init(elems, null);
      instance.close();
    })
  }
  open_modal(){
    var elem = document.getElementById('modal1');
    var instance = M.Modal.init(elem, null);
    instance.open();
  }
}

import { Component, OnInit , DoCheck} from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteService } from 'src/app/services/cliente.service';

import * as CryptoJS from 'crypto-js';
import { environment } from 'src/environments/environment';

import Swal from 'sweetalert2'
import { Router } from '@angular/router';

declare var M: any;

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit, DoCheck {

  public isLoading=true;
  public isValid=false;

  "ID": 0;
  nombre: string=''; //required
  usuario:  string=''; //required
  apellido: string=''; //required
  telefono:string=''; //required
  email: string=''; //required
  dni: number;
  cuil:number;
  direccion:string;
  nacionalidad:string;
  sexo: string;
  password:string=''; //required
  sitacion_crediticia:string;

  constructor(public userService: ClienteService,private ruta: Router) {}

  ngOnInit(): void {
    if (localStorage.getItem("token") != null) {
      this.ruta.navigateByUrl("/clientes")
    }
  }

  async register() {

    let user:Cliente = await new Cliente();
    var key = CryptoJS.enc.Base64.parse(environment.SECRET_KEY);
    var iv  = CryptoJS.enc.Base64.parse("7781157e2629b094f0e3dd48c4d786115");
    
    
    user.Email=this.email.trim();
    user.Apellido=this.apellido.trim();
    user.Pass= CryptoJS.AES.encrypt(this.password.trim(),key, {iv:iv}).toString();
    user.Telefono=this.telefono;
    user.Usuario=this.usuario.trim();
    user.Id=0;
    user.Nombre=this.nombre.trim();
    
    this.userService.postCliente(user).subscribe(data => {
      if (data == "Algo fallo") 
      {M.toast({html: 'El cliente ya existe',classes: 'rounded orange accent-2'})}
      else{
        console.log(data);
        this.ruta.navigate(["/"])
      
      }
      // console.log(user);
    });
  }

  ngDoCheck(){
    //Called every time that the input properties of a component or a directive are checked. Use it to extend change detection by performing a custom check.
    //Add 'implements DoCheck' to the class.
    let user_ok = false;
    let pass_ok = false;



    if((this.usuario !='' && this.usuario.length > 4 && this.usuario.length < 17)){  
      document.getElementById("user_input").classList.remove("invalid")
      document.getElementById("user_input").classList.add("valid")
      user_ok = true;
    } else {
      if(this.usuario ==''){
        document.getElementById("user_input").classList.remove("valid")
        document.getElementById("user_input").classList.remove("invalid")
      }
      else{
      document.getElementById("user_input").classList.remove("valid")
      document.getElementById("user_input").classList.add("invalid")}

      user_ok = false;
    }


    if((this.password !='' && this.password.length > 8 && this.password.length < 17)){ 
      document.getElementById("pass_input").classList.remove("invalid")
      document.getElementById("pass_input").classList.add("valid")
      pass_ok = true
    } else {
      if(this.password ==''){
        document.getElementById("pass_input").classList.remove("valid")
        document.getElementById("pass_input").classList.remove("invalid")
      }else{
      document.getElementById("pass_input").classList.remove("valid")
      document.getElementById("pass_input").classList.add("invalid")
      } 
      pass_ok = false
    }


    if(user_ok && pass_ok && this.apellido !=''&&this.nombre !=''&&this.telefono !=''&&this.email !='' ){
      this.isValid=true;

    }
    else{
      this.isValid = false;
    }
  }
}

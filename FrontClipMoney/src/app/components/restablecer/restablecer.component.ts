import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { RestablecerService } from 'src/app/services/restablecer.service';

import * as CryptoJS from 'crypto-js';
import { environment } from 'src/environments/environment';

import Swal from 'sweetalert2'
import { Router } from '@angular/router';

declare var M: any;

@Component({
  selector: 'app-restablecer',
  templateUrl: './restablecer.component.html',
  styleUrls: ['./restablecer.component.scss']
})
export class RestablecerComponent implements OnInit {
  token: string ;
  id: number ;
  password: string = '';
  password2: string = '';
  constructor(private rutaActiva: ActivatedRoute,public userService: RestablecerService,private ruta: Router) { }

ngOnInit(): void {
  this.token = this.rutaActiva.snapshot.paramMap.get('token');
  this.id =  Number(this.rutaActiva.snapshot.paramMap.get('id'));
  }

change_password(password:string, password2: string){
  var key = CryptoJS.enc.Base64.parse(environment.SECRET_KEY);
  var iv  = CryptoJS.enc.Base64.parse("7781157e2629b094f0e3dd48c4d786115");

  if(password == password2){
    this.userService.cambiar_contraseña(
      CryptoJS.AES.encrypt(this.password.trim(),key, {iv:iv}).toString(),
      this.token,
      this.id).subscribe(data => {
        if (data == "Algo fallo") 
        {M.toast({html: 'Algo fallo intentelo reenviar el email nuevamente',classes: 'rounded orange accent-2'})}
        else{
          console.log(data);
          this.ruta.navigate(["/"])
        }
        // console.log(user);
      });;
  }
}

}

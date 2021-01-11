import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ClienteService} from '../../services/cliente.service'
import {Cliente} from '../../models/cliente.model'

declare var M: any;

@Component({
  selector: 'app-modificacion',
  templateUrl: './modificacion.component.html',
  styleUrls: ['./modificacion.component.scss']
})
export class ModificacionComponent implements OnInit {

  public isLoading=true;
  public isValid=false;

  cliente : Cliente;

  constructor(private clienteService: ClienteService, private ruta: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == null) {
      this.ruta.navigate(["/"])
    }
    else{
      this.obtenerCliente(parseInt(localStorage.getItem("idCliente")));
    }
  }
  obtenerCliente(id: number){
    this.clienteService.getCliente(id)
    .subscribe(resp =>{
      this.cliente = resp
    },
              err => {
                localStorage.removeItem('token')
                localStorage.removeItem('idCliente')
                this.ruta.navigate(["/"])
              },
              () => console.log('yay')
      );
  }
  ngDoCheck(){
    //Called every time that the input properties of a component or a directive are checked. Use it to extend change detection by performing a custom check.
    //Add 'implements DoCheck' to the class.
    

    if(this.cliente.Apellido !=''&&this.cliente.Nombre !=''&&this.cliente.Telefono !=''){
      this.isValid=true;

    }
    else{
      this.isValid = false;
    }
  }
  actualizar_datos(){
    this.clienteService.actualizar_datos(this.cliente).subscribe(data =>{
      if(data == "Cliente actualizado"){
        M.toast({html: 'Cliente actualizado',classes: 'rounded orange accent-2'})
      }
      else{
        M.toast({html: 'Error al actualizar los datos',classes: 'rounded orange accent-2'})
      }
    })
  }

}

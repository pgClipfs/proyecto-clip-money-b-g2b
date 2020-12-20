import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {ClienteService} from '../../services/cliente.service'
import {Cliente} from '../../models/cliente.model'
import { Router } from '@angular/router';


declare var M: any;

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {


  id_cliente: number;
  public cliente: Cliente = new Cliente();
  constructor(private clienteService: ClienteService, private ruta: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == null) {
      this.ruta.navigate(["/"])
    }
    else{
      this.obtenerCliente(parseInt(localStorage.getItem("idCliente")));

    }
    var elems = document.querySelectorAll('.fixed-action-btn');
      var instances = M.FloatingActionButton.init(elems, {direction:'top'});

      var elems = document.querySelectorAll('.sidenav');
      var instances = M.Sidenav.init(elems, {draggable:true});
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

  

}

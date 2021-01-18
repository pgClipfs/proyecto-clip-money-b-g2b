import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor(private ruta: Router) { }

  ngOnInit(): void {
  }

  cerrar_sesion(){
    localStorage.removeItem("token");
    this.ruta.navigate(["/"])
  }
  abrir_config(){
    this.ruta.navigate(["/clientes/perfil"])
  }
  home(){
    this.ruta.navigate(["/clientes"])
  }

}

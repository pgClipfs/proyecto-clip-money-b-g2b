import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Cliente} from '../../models/cliente.model'

declare var M: any;


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit,AfterViewInit {
  Brand = "Navbar";

  @Input() cliente : Cliente;
  
  constructor(private ruta: Router) { }
  
  ngOnInit(): void {
    var elem = document.querySelector('.sidenav');
      var instance = M.Sidenav.init(elem);
      instance.destroy();
  }
  ngAfterViewInit(): void {
    setTimeout( function() {
      var elem = document.querySelector('.sidenav');
      var instance = M.Sidenav.init(elem);
    }, 0)
  }
  cerrar_sesion(){
    localStorage.removeItem("token");
    var elem = document.querySelector('.sidenav');
    var instance = M.Sidenav.init(elem);
    instance.destroy();
    this.ruta.navigate(["/"])
  }
  abrir_config(){
    var elem = document.querySelector('.sidenav');
    var instance = M.Sidenav.init(elem);
    instance.destroy();
    this.ruta.navigate(["/clientes/perfil"])
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Cliente} from '../../models/cliente.model'

declare var M: any;
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  Brand = "Navbar";

  @Input() cliente : Cliente;
  
  constructor(private ruta: Router) {
   }
  
  ngOnInit(): void {
    
  } 
}

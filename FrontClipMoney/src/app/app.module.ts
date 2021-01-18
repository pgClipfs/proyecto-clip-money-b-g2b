import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule,HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ClientesComponent } from './components/clientes/clientes.component'
import { ClienteService } from './services/cliente.service';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginService } from './services/login.service';
import { RestablecerComponent } from './components/restablecer/restablecer.component';
import { ModificacionComponent } from './components/modificacion/modificacion.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClientesComponent,
    LoginComponent,
    RegisterComponent,
    RestablecerComponent,
    ModificacionComponent,
    SidebarComponent,
    
  ],
  imports: [
    HttpClientModule,
    ReactiveFormsModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [ClienteService,LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientesComponent } from './components/clientes/clientes.component';
import { LoginComponent } from './components/login/login.component';
import { ModificacionComponent } from './components/modificacion/modificacion.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RegisterComponent } from './components/register/register.component';
import { RestablecerComponent } from './components/restablecer/restablecer.component';

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'clientes', component:ClientesComponent},
  {path:'register', component:RegisterComponent},
  {path:'restablecer/:token/:id', component:RestablecerComponent},
  {path:'clientes/perfil',component:ModificacionComponent}



];




@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

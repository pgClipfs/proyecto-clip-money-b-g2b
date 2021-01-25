import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ClienteService} from '../../services/cliente.service'
import {Cliente} from '../../models/cliente.model'
import {OperacionesService} from '../../services/operaciones.service'
import { Operacion } from 'src/app/models/operacion.model';
import { CuentaService } from 'src/app/services/cuenta.service';
import { Cuenta } from 'src/app/models/cuenta.model';
import { callbackify } from 'util';

declare var M: any;

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.css']
})
export class OperacionesComponent implements OnInit {

  cliente : Cliente;
  operacion: string ;
  money_op: number;
  Cbu_dest: number;
  public cuenta: Cuenta = new Cuenta();

  constructor(private clienteService: ClienteService, private ruta: Router, private operacionService: OperacionesService,  private cuentaService: CuentaService) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == null) {
      this.ruta.navigate(["/"])
    }
    else{
      this.obtenerCliente(parseInt(localStorage.getItem("idCliente")));
      this.cuentaService.getCuentas(parseInt(localStorage.getItem("idCliente"))).subscribe(data => {
        this.cuenta = data;
        });
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
  seleccionar_op(op: string){
    if (op === "Ingreso" || op === "Extraccion" || op === "Giro_al_descubierto") {
      document.getElementById("Datos").style.visibility ="visible";
      document.getElementById("transferencia").style.visibility ="hidden";
    } else {
      if (op === "Transferencia") {
        document.getElementById("Datos").style.visibility ="visible";
        document.getElementById("transferencia").style.visibility ="visible";
      } else {
        console.log("Algo Fallo");
      }
    }
    this.operacion = op;
  }
  realizar_op(){
    console.log('im in')
    if(this.money_op == 0 || this.money_op == null ){
      M.toast({html: 'Ingrese un valor valido para realizar la operacion',classes: 'rounded orange accent-2'})
    }
    else{
      console.log(this.cuenta);
      let nuevaOp = new Operacion();
      nuevaOp.monto = this.money_op;
      nuevaOp.id_cuenta = this.cuenta.Id;
      if(this.operacion == "Ingreso"){
        this.operacionService.generar_ingreso(nuevaOp).subscribe(data =>{
          console.log(data);
          document.getElementById("Resultado").style.visibility ="visible";
          if(data === "Algo fallo"){
            document.getElementById("falla").style.visibility ="visible";
          }
          else{
            document.getElementById("working").style.visibility ="visible";
          }
        })
        
      }else{  
      if(this.operacion == "Extraccion"){
        if(nuevaOp.monto > this.cuenta.Saldo){
          M.toast({html: 'No posee ese saldo',classes: 'rounded orange accent-2'})
        }
        else{
          this.operacionService.generar_extraccion(nuevaOp).subscribe(data =>{
            console.log(data);
            document.getElementById("Resultado").style.visibility ="visible";
            if(data === "Algo fallo"){
              document.getElementById("falla").style.visibility ="visible";
            }
            else{
              document.getElementById("working").style.visibility ="visible";
            }
          });
        }    
        }
        else{
          if (this.operacion == "Giro_al_descubierto") {
            this.operacionService.generar_giro(nuevaOp).subscribe(data =>{
              console.log(data);
              document.getElementById("Resultado").style.visibility ="visible";
              if(data === "Algo fallo"){
                document.getElementById("falla").style.visibility ="visible";
              }
              else{
                document.getElementById("working").style.visibility ="visible";
              }
            });
          }else {
            if (this.operacion == "Transferencia") {
              var cbu = "";
              for(var i = 0; i < this.Cbu_dest.toString().length; i++){
                cbu = cbu + this.Cbu_dest.toString()[i];
                if (i == 2 || i == 6 || i== 10|| i == 14 ) {
                  cbu = cbu + " ";
                }
              }
              nuevaOp.Destino = cbu;
              nuevaOp.Origen = this.cuenta.Cbu;
              this.operacionService.generar_transferencia(nuevaOp).subscribe(data =>{
                console.log(data);
                document.getElementById("Resultado").style.visibility ="visible";
                if(data === "Algo fallo"){
                  document.getElementById("falla").style.visibility ="visible";
                }
                else{
                  document.getElementById("working").style.visibility ="visible";
                }
              });
            }
          }
        }
      
      }
    }
  }
}

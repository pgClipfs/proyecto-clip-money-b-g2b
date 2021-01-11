import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {ClienteService} from '../../services/cliente.service'
import {Cliente} from '../../models/cliente.model'
import { Router } from '@angular/router';
import { isBoolean } from 'util';
import { CuentaService } from 'src/app/services/cuenta.service';
import { Cuenta } from 'src/app/models/cuenta.model';
import { Operacion } from 'src/app/models/operacion.model';
import { OperacionesService } from 'src/app/services/operaciones.service';


declare var M: any;

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  ImageBaseData:string | ArrayBuffer=null;
  id_cliente: number;
  money_op: number;
  operacion: string ;
  ultimas_op: Operacion[];
  public cliente: Cliente = new Cliente();
  public cuenta: Cuenta = new Cuenta();
  constructor(private clienteService: ClienteService, private ruta: Router, private cuentaService: CuentaService, private operacionService: OperacionesService) { }

  ngOnInit(): void {
    
    this.operacion = "Ingreso";

    if (localStorage.getItem("token") == null) {
      this.ruta.navigate(["/"])
    }
    else{
      this.obtenerCliente(parseInt(localStorage.getItem("idCliente")));
    }

    this.clienteService.existe_documento(parseInt(localStorage.getItem("idCliente"))).subscribe(data =>{
      if(data == 'true'){
        document.getElementById("doc_btn").style.display= "none";
        document.getElementById("row_cuenta").style.display= "block";
      }
    });
    
    this.cuentaService.getCuentas(parseInt(localStorage.getItem("idCliente"))).subscribe(data => {
      this.cuenta = data;
    });


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

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      me.ImageBaseData=reader.result;
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }

 btnUpload(){
    
  if(this.ImageBaseData==null){
    alert("Please select file");
  }else{     
    this.clienteService.cargar_documento(parseInt(localStorage.getItem("idCliente")) ,this.ImageBaseData.toString()).subscribe(data=>{
      console.log(data);
    })
    let nuevacuenta = new Cuenta();
    nuevacuenta.num_de_cuenta = 123;
    nuevacuenta.Saldo = 0;
    nuevacuenta.tipo_de_cuenta = "Pesos";
    nuevacuenta.estado_de_cuenta = "Activa";
    nuevacuenta.cbu = 123;
    nuevacuenta.cvu = 123;
    nuevacuenta.id_cliente = parseInt(localStorage.getItem("idCliente"));

    this.cuentaService.postCuenta(nuevacuenta).subscribe(data=>{
      if(data == "Algo Fallo"){
        console.log(data);
      }
      else{
        this.ruta.navigateByUrl("/")
      }
    })
  }
 }

 open_modal(id: string){
  var elem = document.getElementById(id);
  var instance = M.Modal.init(elem, null);
  instance.open();

  if(id == 'modal3'){
    
    this.operacionService.ultimos_movimientos(this.cuenta.Id).subscribe(data =>{
      this.ultimas_op = data;
    })
  }
}

select_op(value: string){
  this.operacion = value;
}

realizar_op(){
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
        this.ruta.navigateByUrl("/")
      })
      
    }else{  
    if(this.operacion == "Extraccion"){
      if(nuevaOp.monto > this.cuenta.Saldo){
        M.toast({html: 'No posee ese saldo',classes: 'rounded orange accent-2'})
      }
      else{
        this.operacionService.generar_extraccion(nuevaOp).subscribe(data =>{
          console.log(data);
          this.ruta.navigateByUrl("/")
        });
      }    
      }
    }
    
  }
}
}

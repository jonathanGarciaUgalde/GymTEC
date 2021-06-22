import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';
import { ActivatedRoute } from '@angular/router'; // Importar

@Component({
  selector: 'app-busqueda-periodo',
  templateUrl: './busqueda-periodo.component.html',
  styleUrls: ['./busqueda-periodo.component.css']
})
export class BusquedaPeriodoComponent implements OnInit {

  cedulaCliente:string = "";

  constructor(private router:Router, private api:ClienteService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.cedulaCliente = this.route.snapshot.paramMap.get("cedula")!;
  }

  public clases: Clase[] = [];

  public datosClaseXPeriodo = {
    PeriodoUno : "",
    PeriodoDos : ""
  }

  cargarClasesPorPeriodo(){

    if(this.datosClaseXPeriodo.PeriodoUno != "" || this.datosClaseXPeriodo.PeriodoDos != ""){
      this.api.obtenerClasesPorPeriodo(this.datosClaseXPeriodo.PeriodoUno, this.datosClaseXPeriodo.PeriodoDos)
      .subscribe(response => {
      
        this.clases = response;

      },(error:any)=>{
        console.log(error);
        });
    }else{
      alert("Debe ingresar ambos periodos");
    }

  }

  registrarClase(camposClase : Clase){
    console.log(camposClase.idClase);

    var IdClase:number = camposClase.idClase!;

    this.api.registrarClientePorClase(IdClase, this.cedulaCliente)
    .subscribe(response => {
    
      console.log(response);
      

    },(error:any)=>{
      console.log(error);
      });
  }

}

import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';
import { ActivatedRoute } from '@angular/router'; // Importar

@Component({
  selector: 'app-busqueda-sucursal',
  templateUrl: './busqueda-sucursal.component.html',
  styleUrls: ['./busqueda-sucursal.component.css']
})
export class BusquedaSucursalComponent implements OnInit {

  cedulaCliente:string = "";

  constructor(private router:Router, private api:ClienteService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.cedulaCliente = this.route.snapshot.paramMap.get("cedula")!;
  }

  public clases: Clase[] = [];

  public datosClaseXSucursal = {
    IdSucursal : ""
  }

  cargarClasesPorSucursal(){

    if(this.datosClaseXSucursal.IdSucursal != ""){
      this.api.obtenerClasesPorSucursal(this.datosClaseXSucursal.IdSucursal)
      .subscribe(response => {
      
        this.clases = response;

      },(error:any)=>{
        console.log(error);
        });
    }else{
      alert("Debe ingresar un Id Sucursal");
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

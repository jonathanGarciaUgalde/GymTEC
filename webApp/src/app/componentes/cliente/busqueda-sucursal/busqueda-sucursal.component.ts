import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';

@Component({
  selector: 'app-busqueda-sucursal',
  templateUrl: './busqueda-sucursal.component.html',
  styleUrls: ['./busqueda-sucursal.component.css']
})
export class BusquedaSucursalComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  ngOnInit(): void {
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
        console.log(response[0].capacidad);
        console.log(response.length);
        

      },(error:any)=>{
        console.log(error);
        });
    }else{
      alert("Debe ingresar un Id Sucursal");
    }

  }

  registrarClase(capacidad: Clase){
    console.log(capacidad.capacidad);
    
  }

}

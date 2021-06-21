import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';

@Component({
  selector: 'app-busqueda-periodo',
  templateUrl: './busqueda-periodo.component.html',
  styleUrls: ['./busqueda-periodo.component.css']
})
export class BusquedaPeriodoComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  ngOnInit(): void {
  }

  public clases: Clase[] = [
    {
      capacidad : 7,
      esGrupal : true,
      dia : "05/06/2021",
      horaInicio : "5:30",
      horaFinal : "7:00",
      nombreServicio : "Zumba",
      nombreEmpleado : "Alan",
      idSucursal : 5
    }
  ]

  public datosClaseXSucursal = {
    IdSucursal : "",
    IdSucursal1 : ""
  }

  cargarClasesPorSucursal(){
    console.log("---");
  }

  registrarClase(capacidad: Clase){
    console.log(capacidad.capacidad);
    
  }

}

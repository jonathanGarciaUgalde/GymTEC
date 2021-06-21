import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';

@Component({
  selector: 'app-busqueda-tipo-clase',
  templateUrl: './busqueda-tipo-clase.component.html',
  styleUrls: ['./busqueda-tipo-clase.component.css']
})
export class BusquedaTipoClaseComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  ngOnInit(): void {
  }

  public clases: Clase[] = [
    {
      capacidad : 12,
      esGrupal : true,
      dia : "25/12/12",
      horaInicio : "1:30",
      horaFinal : "2:00",
      nombreServicio : "Pilates",
      nombreEmpleado : "Josue",
      idSucursal : 4
    }
  ]

  public datosClaseXSucursal = {
    IdSucursal : ""
  }

  cargarClasesPorSucursal(){
    console.log("---");
  }

  registrarClase(capacidad: Clase){
    console.log(capacidad.capacidad);
    
  }

}

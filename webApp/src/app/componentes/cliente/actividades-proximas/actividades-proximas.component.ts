import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import {Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';

@Component({
  selector: 'app-actividades-proximas',
  templateUrl: './actividades-proximas.component.html',
  styleUrls: ['./actividades-proximas.component.css']
})
export class ActividadesProximasComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  public clases: Clase[] = [];

  /*clases: Clase[] = [
    {
      capacidad : 0,
      esGrupal : true,
      dia : "10/10/10",
      horaInicio : "3:00pm",
      horaFinalizacion : "4:00pm",
      tipoClase : "Indoor Cycling",
      empleado : "Javier Soto",
      idSucursal : 3
    }
  ]*/

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import {Router} from '@angular/router';
import { Clase } from '../../../interfaces/clase.interface';
import { ActivatedRoute } from '@angular/router'; // Importar

@Component({
  selector: 'app-actividades-proximas',
  templateUrl: './actividades-proximas.component.html',
  styleUrls: ['./actividades-proximas.component.css']
})
export class ActividadesProximasComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService, private route: ActivatedRoute) { 
  }

  ngOnInit(): void {
    let cedulaCliente:string = this.route.snapshot.paramMap.get("cedula")!;
    this.cargarActividadesProximas(cedulaCliente); 
  }

  public clases: Clase[] = [];

  cargarActividadesProximas(correoCliente:string){

    this.api.obtenerActividadesProximas(correoCliente)
    .subscribe(response => {

      this.clases = response;
      
    },(error:any)=>{
      console.log(error);
      });

  }

}

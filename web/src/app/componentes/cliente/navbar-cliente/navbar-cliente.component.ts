import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router'; // Importar
import {Router} from '@angular/router';

@Component({
  selector: 'app-navbar-cliente',
  templateUrl: './navbar-cliente.component.html',
  styleUrls: ['./navbar-cliente.component.css']
})
export class NavbarClienteComponent implements OnInit {

  cedulaCliente:string = "";

  constructor(private router:Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.cedulaCliente = this.route.snapshot.paramMap.get("cedula")!;    
  }

  busqueda_sucursal(){
    this.router.navigate(["/busqueda-sucursal", { cedula: this.cedulaCliente }]);
  }

  busqueda_tipo_clase(){
    this.router.navigate(["/busqueda-tipo-clase", { cedula: this.cedulaCliente }]);
  }

  busqueda_periodo(){
    this.router.navigate(["/busqueda-periodo", { cedula: this.cedulaCliente }]);
  }

}

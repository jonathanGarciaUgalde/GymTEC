import { Component, OnInit } from '@angular/core';

import {AdminService} from 'src/app/servicios/admin/admin.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public api:AdminService) { }

  public datosUsuario = {
    Email:null,
    Password:null
  }

  ngOnInit(): void {
  }

  verificarCredenciales():void {

  	this.api.LoginAdmin(this.datosUsuario.Email, this.datosUsuario.Password)
  	.subscribe(response=>{

      if (response !== null){
        console.log(response);
        
        /*var cedulaCliente = response.toString();
        this.router.navigate(["/actividades-proximas", { cedula: cedulaCliente }]);*/
      }else{
        alert("Usuario o contraseña incorrecta, intente de nuevo");
      }
      
  	},(error:any)=>{
        alert("¡Error al intentar conectar con el server!");
        this.datosUsuario.Password = "";
      });
  }

}

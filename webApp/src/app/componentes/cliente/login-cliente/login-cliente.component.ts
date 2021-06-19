import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login-cliente',
  templateUrl: './login-cliente.component.html',
  styleUrls: ['./login-cliente.component.css']
})
export class LoginClienteComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  ngOnInit(): void {
  }

  public datosUsuario = {
    Email : "",
    Password : ""
  }

  verificarCredenciales():void {

  	this.api.LoginCliente(this.datosUsuario.Email, this.datosUsuario.Password)
  	.subscribe(response=>{

      // LocalStorage permite almacenar datos en el navegador web. Y que estos persistan y estén 
      // disponibles durante la navegación en la aplicación web, hasta que esta información sea borrada del navegador.
      // Ej: Consultar en el navegador:
      // this.dato = localStorage.getItem('email-cliente');
      // console.log(this.dato);
  		localStorage.setItem("email-cliente", this.datosUsuario.Email);
      localStorage.setItem("pass-cliente", this.datosUsuario.Password);
  		
      if (response === true){
        this.router.navigate(["/actividades-proximas"]);
      }else{
        alert("Usuario o contraseña incorrecta, intente de nuevo");
      }
      
  	},(error:any)=>{
        alert("Error al intentar conectar con el server");
        this.datosUsuario.Password = "";
      });
  }


}

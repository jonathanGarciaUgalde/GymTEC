import { Component, OnInit } from '@angular/core';

import {AdminService} from 'src/app/servicios/admin/admin.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router, public api:AdminService) { }

  public datosUsuario = {
    Email:"",
    Password:""
  }

  ngOnInit(): void {
  }

  verificarCredenciales():void {

      if(this.datosUsuario.Email != "" && this.datosUsuario.Password != ""){
        this.api.LoginAdmin(this.datosUsuario.Email, this.datosUsuario.Password)
        .subscribe(response=>{
    
          if (response !== null){
            alert("Bienvenido al sistema Administrativo. Su puesto es como: " + response.toString());
            this.router.navigate(["/admin/sucursales"]);
          }else{
            alert("Usuario o contraseña incorrecta, intente de nuevo");
          }
          
        },(error:any)=>{
            alert("¡Error al intentar conectar con el server!");
            this.datosUsuario.Password = "";
          });
      }else{
        alert("Debe ingresar su correo y contraseña");
      }
  }

}

import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../../interfaces/usuario.interface';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url:string = "https://localhost:44318/api/";

  constructor(private http:HttpClient ) { }

  LoginCliente(email:string, pass:string){
    
    let direccion = this.url + "Cliente/LoginCliente";
    
  	return this.http.post(direccion,
      {
        User: email,
        Pass: pass
      });
    
  }

  InsertCliente(user:Usuario){
    
    let direccion = this.url + "Cliente/insertCliente";

    return this.http.post(direccion,
      {

        Nombre : user.nombre,
        Apellidos : user.apellidos,
        Cedula : user.cedula,
        Edad : user.edad,
        Nacimiento : user.fecha_nacimiento,
        Peso : user.peso,
        IMC : user.imc,
        Direccion : user.direccion,
        Correo: user.correo,
        Pass : user.contrasena

      });  
    
  }

}

import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../../interfaces/usuario.interface';
import { Clase } from '../../interfaces/clase.interface';
import { Observable, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url:string = "https://localhost:44318/api/";
  urlSQLServer:string = "https://localhost:52217/api/";

  constructor(private http:HttpClient ) { }

  /*public claseActual: Clase = {

    capacidad : 0,
    esGrupal : true,
    dia : "",
    horaInicio : "",
    horaFinalizacion : "",
    tipoClase : "",
    empleado : "",
    idSucursal : 0

  }*/

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

  obtenerClasesPorSucursal(IdSucursal:string) : Observable<any> {

    let direccion = this.urlSQLServer + "Clase/clasePorSucursal/" + IdSucursal;

  	return this.http.get(direccion);
  }

}

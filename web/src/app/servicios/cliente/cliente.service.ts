import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Usuario } from '../../interfaces/usuario.interface';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url:string = "https://localhost:44318/api/";
  urlSQLServer:string = "https://localhost:44307/api/";

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

  obtenerActividadesProximas(CedulaCliente:string) : Observable<any> {

    let direccion = this.urlSQLServer + "ClientePorClase/ProximasActividades/" + CedulaCliente;

  	return this.http.get(direccion);
  }

  obtenerClasesPorSucursal(IdSucursal:string) : Observable<any> {

    let direccion = this.urlSQLServer + "Clase/ClasePorSucursal/" + IdSucursal;

  	return this.http.get(direccion);
  }

  obtenerClasesPorTipoClase(TipoClase:string) : Observable<any> {

    let direccion = this.urlSQLServer + "Clase/ClasePorTipo";

    return this.http.post(direccion,
      {

        Id : 0,
        Nombre : TipoClase,
        Descripcion : "",
        IdSucursal : 0

      }); 

  }
  
  obtenerClasesPorPeriodo(PeriodoUno:string, PeriodoDos:string) : Observable<any> {

    let direccion = this.urlSQLServer + "Clase/ClasePorPeriodo";

    return this.http.post(direccion,
      {

          Id : 0,
          Capacidad : 0,
          EsGrupal : true,
          Dia : "",
          HoraInicio : PeriodoUno,
          HoraFinal : PeriodoDos,
          Tipo : 0,
          Empleado : "",
          IdSucursal : 0
    
      }); 

  }

  registrarClientePorClase(IdClase:number, CedulaCliente:string) : Observable<any> {

    let direccion = this.urlSQLServer + "ClientePorClase";

    return this.http.post(direccion,
      {

        Id : 0,
        Clase : IdClase,
        Cliente : CedulaCliente

      }); 

  }

}

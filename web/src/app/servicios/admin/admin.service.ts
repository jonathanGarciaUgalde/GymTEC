import { Injectable } from '@angular/core';

import {HttpClient, HttpHeaders} from "@angular/common/http"
import {Observable} from "rxjs/internal/Observable";

import {NgForm} from "@angular/forms";



@Injectable({
	providedIn: 'root'
})
export class AdminService {

	constructor(private http:HttpClient) { }

	baseURL:string = "https://localhost:44307/api";


	/*Peticiones asociadas a las sucursales*/

	obtenerSucursales(){
		const url = this.baseURL + "/Sucursal";
		return this.http.get(url);
	}

	crearSucursal(sucursalForm: NgForm){
		const url = this.baseURL + "/Sucursal"
		return this.http.post(url,{  		
			"Capacidad": sucursalForm.value.capacidad,
			"Nombre": sucursalForm.value.nombre,
			"Provincia": sucursalForm.value.provincia,
			"Canton": sucursalForm.value.canton,
			"Distrito": sucursalForm.value.distrito
		});
	}

	eliminarSucursal(sucursal:any){
		const url = this.baseURL + "/Sucursal/" + sucursal.id 
		return this.http.delete(url);
	}

	actualizarSucursal(sucursalForm: NgForm, id:number){
		const url = this.baseURL + "/Sucursal/" + id
		return this.http.put(url,{
			"id": id,
			"Capacidad": sucursalForm.value.capacidad,
			"Nombre": sucursalForm.value.nombre,
			"Provincia": sucursalForm.value.provincia,
			"Canton": sucursalForm.value.canton,
			"Distrito": sucursalForm.value.distrito
		});
	}

	activarTienda(id:number){
		const url = this.baseURL + "/Sucursal/ActivarTienda/" + id;
		return this.http.put(url,{});
	}

	activarSpa(id:number){
		const url = this.baseURL + "/Sucursal/ActivarSpa/" + id;
		return this.http.put(url,{});
	}

	obtenerTelefonos(id:number){
		const url = this.baseURL + "/Telefono/" + id;
		return this.http.get(url);
	}


	/*Peticiones asociadas a la planilla*/

	obtenerPlanillas(){
		const url = this.baseURL + "/Planilla";
		return this.http.get(url);
	}

	crearPlanilla(planillaForm: NgForm){
		const url = this.baseURL + "/Planilla"
		return this.http.post(url,{  		
			"Cargo": planillaForm.value.cargo,
			"Mensual": planillaForm.value.mensual,
			"Hora": planillaForm.value.hora,
			"Clase": planillaForm.value.clase,
			"Cedula": planillaForm.value.cedula,
			"IdSucursal": planillaForm.value.idSucursal
		});
	}

	eliminarPlanilla(planilla:any){
		const url = this.baseURL + "/Planilla/" + planilla.id 
		return this.http.delete(url);
	}

	actualizarPlanilla(planillaForm: NgForm, id:number, idSucursal:number){
		const url = this.baseURL + "/Planilla/" + id;

		var cedula:string;

		if(planillaForm.value.cedula == ""){
			cedula = null
		}
		else{
			cedula = planillaForm.value.cedula;
		}

		return this.http.put(url,{
			"Id":id,
			"Cargo": planillaForm.value.cargo,
			"Mensual": planillaForm.value.mensual,
			"Hora": planillaForm.value.hora,
			"Clase": planillaForm.value.clase,
			"Cedula": cedula,
			"IdSucursal": idSucursal
		});
	}

	/*---Peticiones asociadas a productos----*/

	obtenerProductos(){
		const url = this.baseURL + "/Producto";
		return this.http.get(url);
	}

	crearProducto(productoForm: NgForm){
		const url = this.baseURL + "/Producto"
		return this.http.post(url,{  		
			"Codigo": productoForm.value.codigo,
			"Nombre": productoForm.value.nombre,
			"Descripcion": productoForm.value.descripcion,
			"Costo": productoForm.value.costo,
			"IdSucursal": productoForm.value.idSucursal
		});
	}

	eliminarProducto(producto:any){
		const url = this.baseURL + "/Producto/" + producto.codigo 
		return this.http.delete(url);
	}

	actualizarProducto(productoForm: NgForm, codigo){
		const url = this.baseURL + "/Producto"
		return this.http.put(url,{
			"Codigo":codigo,
			"Nombre": productoForm.value.nombre,
			"Descripcion": productoForm.value.descripcion,
			"Costo": productoForm.value.costo,
			"IdSucursal": productoForm.value.idSucursal
		});
	}


	/*---Peticiones asociadas a Servicios----*/

	obtenerServicios(){
		const url = this.baseURL + "/Servicio";
		return this.http.get(url);
	}

	crearServicio(servicioForm: NgForm){
		const url = this.baseURL + "/Servicio"
		return this.http.post(url,{  		
			"Nombre": servicioForm.value.nombre,
			"Descripcion": servicioForm.value.descripcion,
			"IdSucursal": servicioForm.value.idSucursal
		});
	}

	eliminarServicio(servicio:any){
		const url = this.baseURL + "/Servicio/" + servicio.id 
		return this.http.delete(url);
	}

	actualizarServicio(servicioForm: NgForm, codigo){
		const url = this.baseURL + "/Servicio/" + codigo
		return this.http.put(url,{
			"Id":codigo,
			"Nombre": servicioForm.value.nombre,
			"Descripcion": servicioForm.value.descripcion,
			"IdSucursal": servicioForm.value.idSucursal
		});
	}


	/*--------------Peticiones asociadas al empleado----------*/

	obtenerEmpleados(){
		const url = this.baseURL + "/Empleado";
		return this.http.get(url);
	}

	crearEmpleado(empleadoForm: NgForm){
		const url = this.baseURL + "/Empleado"
		return this.http.post(url,{  		
			"Nombre": empleadoForm.value.nombre,
			"Cedula": empleadoForm.value.cedula,
			"Email": empleadoForm.value.email,
			"Apellido": empleadoForm.value.apellido,
			"Provincia": empleadoForm.value.provincia,
			"Distrito": empleadoForm.value.distrito,
			"Canton": empleadoForm.value.canton,
			"Password": empleadoForm.value.password,
			"IdSucursal": empleadoForm.value.sucursal,
			"IdPlanilla": empleadoForm.value.planilla
		});
	}

	eliminarEmpleado(empleado:any){
		const url = this.baseURL + "/Empleado/" + empleado.cedula 
		return this.http.delete(url);
	}

	actualizarEmpleado(empleadoForm: NgForm, cedula){
		const url = this.baseURL + "/Empleado/" + cedula
		return this.http.put(url,{
			"Nombre": empleadoForm.value.nombre,
			"Cedula": empleadoForm.value.cedula,
			"Email": empleadoForm.value.email,
			"Apellido": empleadoForm.value.apellido,
			"Provincia": empleadoForm.value.provincia,
			"Distrito": empleadoForm.value.distrito,
			"Canton": empleadoForm.value.canton,
			"Password": empleadoForm.value.password,
			"IdSucursal": empleadoForm.value.sucursal,
			"IdPlanilla": empleadoForm.value.planilla
		});
	}

		/*--------------Peticiones asociadas al equipo----------*/

	obtenerEquipos(){
		const url = this.baseURL + "/Equipo";
		return this.http.get(url);
	}

	crearEquipo(equipoForm: NgForm){
		const url = this.baseURL + "/Equipo"
		return this.http.post(url,{  		
			"Serie": equipoForm.value.serie,
			"Marca": equipoForm.value.marca,
			"Costo": equipoForm.value.costo,
			"Tipo": equipoForm.value.tipo,
			"Descripcion": equipoForm.value.descripcion,
			"IdSucursal": equipoForm.value.idSucursal
		});
	}

	eliminarEquipo(equipo:any){
		const url = this.baseURL + "/Equipo/" + equipo.serie 
		return this.http.delete(url);
	}

	actualizarEquipo(equipoForm: NgForm, serie){
		const url = this.baseURL + "/Equipo/" + serie
		return this.http.put(url,{
			"Serie":serie,
			"Marca": equipoForm.value.marca,
			"Costo": equipoForm.value.costo,
			"Tipo": equipoForm.value.tipo,
			"Descripcion": equipoForm.value.descripcion,
			"IdSucursal": equipoForm.value.idSucursal
		});
	}


			/*--------------Peticiones asociadas al tipos----------*/

	obtenerTipos(){
		const url = this.baseURL + "/TipoMaquina";
		return this.http.get(url);
	}

	crearTipo(tipoForm: NgForm){
		const url = this.baseURL + "/TipoMaquina"
		return this.http.post(url,{  		
			"Tipo": tipoForm.value.tipo,
			"Descripcion": tipoForm.value.descripcion
		});
	}

	eliminarTipo(tipo:any){
		const url = this.baseURL + "/TipoMaquina/" + tipo.serie 
		return this.http.delete(url);
	}

	actualizarTipo(equipoForm: NgForm, tipo){
		const url = this.baseURL + "/TipoMaquina/" + tipo
		return this.http.put(url,{
			"Tipo":tipo,
			"Descripcion": equipoForm.value.descripcion,
		});
	}


	// Servicios -> David
	LoginAdmin(email:string, pass:string){
    
		let direccion = this.baseURL + "/Empleado/Login";
		
		  return this.http.post(direccion,
		  {
			Cedula : "",
			Email : email,
			Password : pass,
			Nombre : "",
			Apellido : "",
			Provincia : "",
			Tipo : "",
			Canton : "",
			Distrito : "",
			IdSucursal : 0
		  },
		  {responseType: 'text'}
		  );
		
	  }




}

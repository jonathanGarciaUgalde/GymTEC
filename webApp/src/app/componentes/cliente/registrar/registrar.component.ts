import { Component, OnInit } from '@angular/core';

import { ClienteService } from '../../../servicios/cliente/cliente.service';
import { Usuario } from '../../../interfaces/usuario.interface';
import {Router} from '@angular/router';


@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css']
})
export class RegistrarComponent implements OnInit {

  constructor(private router:Router, private api:ClienteService) { }

  ngOnInit(): void {
  }

  public datosUsuario = {
  	nombre: "",
  	apellidos: "",
    cedula : 0,
  	edad: 0,
    fecha_nacimiento:  "",
  	peso: 0,
    imc: 0,
  	direccion: "",
  	email: "",
  	contrasena: "",
  }

  registrar(){

    const user = this.datosUsuario;

    const usuarioFinal:Usuario ={};
  	usuarioFinal.nombre = user.nombre;
  	usuarioFinal.apellidos = user.apellidos;
  	usuarioFinal.cedula = user.cedula;
  	usuarioFinal.edad = user.edad;
    usuarioFinal.fecha_nacimiento = user.fecha_nacimiento;
  	usuarioFinal.imc = user.imc;
    usuarioFinal.direccion = user.direccion;
    usuarioFinal.correo = user.email;
  	usuarioFinal.contrasena = user.contrasena;

    this.api.InsertCliente(usuarioFinal)
  	.subscribe(response=>{
      
      alert("Usuario registrado");
  		this.router.navigate(["/login"]);

  	},(error:any)=>{
      alert("Error al intentar conectar con el server");
    });

  }

}

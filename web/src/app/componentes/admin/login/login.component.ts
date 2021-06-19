import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  public datosUsuario = {
    Email:null,
    Password:null
  }

  ngOnInit(): void {
  }


    verificarCredenciales():void{

  	
  } 

}

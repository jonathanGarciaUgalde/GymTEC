import { Component, OnInit } from '@angular/core';

import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-equipo',
  templateUrl: './equipo.component.html',
  styleUrls: ['./equipo.component.css']
})
export class EquipoComponent implements OnInit {

  constructor(private modalService: NgbModal, public api:AdminService) { }

  ngOnInit(): void {
    this.obtenerEquipos();

  }

    public equipos:any[];

  public actualizar:boolean;

  public closeResult: string;

  public equipoActual = {
    serie:null,
    marca:null,
    costo:null,
    descripcion:null,
    tipo:null,
    idSucursal: null
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = 'Closed with: ${result}';
    }, (reason) => {
      this.closeResult = 'Dismissed ${this.getDismissReason(reason)}';
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  obtenerEquipos(){
    this.api.obtenerEquipos()
    .subscribe((response:any[])=>{this.equipos = response});
  }


  crearNuevo(content){
    this.limpiarForm();
    this.actualizar = false;

    this.open(content);
  }

  actualizarEquipo(content, equipo:any){

    this.equipoActual = equipo;
    this.actualizar = true;
    this.open(content);
  }

  eliminarEquipo(equipo:any){
    if (confirm('¿Está seguro que quiere eliminar el equipo?')){
      this.api.eliminarEquipo(equipo)
      .subscribe(response=>location.reload());
    }
  }


  guardarEquipo(equipoForm: NgForm):void{

    this.modalService.dismissAll();


    if(this.actualizar){
      this.api.actualizarEquipo(equipoForm, this.equipoActual.serie).subscribe(response=>location.reload());
    }
    else{
      this.api.crearEquipo(equipoForm).subscribe(response=>location.reload());
    }  

  }


  limpiarForm():void{
    this.equipoActual.serie = null,
    this.equipoActual.marca= null,
    this.equipoActual.costo= null,
    this.equipoActual.descripcion= null,
    this.equipoActual.idSucursal= 0 
  }

}

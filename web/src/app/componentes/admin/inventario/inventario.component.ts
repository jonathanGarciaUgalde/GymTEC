import { Component, OnInit } from '@angular/core';

import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrls: ['./inventario.component.css']
})
export class InventarioComponent implements OnInit {

	  constructor(private modalService: NgbModal, public api:AdminService) { }

  ngOnInit(): void {
    //this.obtenerTipos();

  }

    public tipos:any[];

  public actualizar:boolean;

  public closeResult: string;

  public tipoActual = {
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

  obtenerTipos(){
    this.api.obtenerTipos()
    .subscribe((response:any[])=>{this.tipos = response});
  }


  crearNuevo(content){
    this.limpiarForm();
    this.actualizar = false;

    this.open(content);
  }

  actualizarTipo(content, tipo:any){

    this.tipoActual = tipo;
    this.actualizar = true;
    this.open(content);
  }

  eliminarTipo(tipo:any){
    if (confirm('¿Está seguro que quiere eliminar el tipo?')){
      this.api.eliminarTipo(tipo)
      .subscribe(response=>location.reload());
    }
  }


  guardarTipo(tipoForm: NgForm):void{

    this.modalService.dismissAll();


    if(this.actualizar){
      this.api.actualizarTipo(tipoForm, this.tipoActual.serie).subscribe(response=>location.reload());
    }
    else{
      this.api.crearTipo(tipoForm).subscribe(response=>location.reload());
    }  

  }


  limpiarForm():void{
    this.tipoActual.serie = null,
    this.tipoActual.marca= null,
    this.tipoActual.costo= null,
    this.tipoActual.descripcion= null,
    this.tipoActual.idSucursal= 0 
  }

}



import { Component, OnInit } from '@angular/core';

import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-servicios',
  templateUrl: './servicios.component.html',
  styleUrls: ['./servicios.component.css']
})
export class ServiciosComponent implements OnInit {

  constructor(private modalService: NgbModal, public api:AdminService) { }

  ngOnInit(): void {
  	this.obtenerServicios();

  }

  	public servicios:any[];

	public actualizar:boolean;

	public closeResult: string;

	public servicioActual = {
		id:null,
		nombre:null,
		descripcion:null,
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

	obtenerServicios(){
		this.api.obtenerServicios()
		.subscribe((response:any[])=>{this.servicios = response});
	}


	crearNuevo(content){
		this.limpiarForm();
		this.actualizar = false;

		this.open(content);
	}

	actualizarServicio(content, servicio:any){

		this.servicioActual = servicio;
		this.actualizar = true;
		this.open(content);
	}

	eliminarServicio(servicio:any){
		if (confirm('¿Está seguro que quiere eliminar el servicio?')){
			this.api.eliminarServicio(servicio)
			.subscribe(response=>location.reload());
		}
	}


	guardarServicio(servicioForm: NgForm):void{

		this.modalService.dismissAll();


		if(this.actualizar){
			this.api.actualizarServicio(servicioForm, this.servicioActual.id).subscribe(response=>location.reload());
		}
		else{
			this.api.crearServicio(servicioForm).subscribe(response=>location.reload());
		}  

	}


	limpiarForm():void{
		this.servicioActual.id = null,
		this.servicioActual.nombre= null,
		this.servicioActual.descripcion= null,
		this.servicioActual.idSucursal= 0 
	}

}

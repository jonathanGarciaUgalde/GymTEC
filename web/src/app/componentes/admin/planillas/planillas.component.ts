import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-planillas',
	templateUrl: './planillas.component.html',
	styleUrls: ['./planillas.component.css']
})
export class PlanillasComponent implements OnInit {

	constructor(private modalService: NgbModal, public api:AdminService) { }

	public planillas:any[];

	public actualizar:boolean;

	public closeResult: string;

	public planillaActual = {
		id: null,
		cargo: null,
		mensual: null,
		hora: null,
		clase: null,
		cedula:null,
		idSucursal: null
	}

	ngOnInit(): void {
		this.obtenerPlanillas();
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

	obtenerPlanillas(){
		this.api.obtenerPlanillas()
		.subscribe((response:any[])=>{this.planillas = response});
	}


	crearNuevo(content){
		this.limpiarForm();
		this.actualizar = false;

		this.open(content);
	}

	actualizarPlanilla(content, planilla:any){

		this.planillaActual = planilla;
		this.actualizar = true;
		this.open(content);
	}

	eliminarPlanilla(planilla:any){
		if (confirm('¿Está seguro que quiere eliminar la planilla?')){
			this.api.eliminarPlanilla(planilla)
			.subscribe(response=>location.reload());
		}
	}


	guardarPlanilla(planillaForm: NgForm):void{

		this.modalService.dismissAll();


		if(this.actualizar){
			this.api.actualizarPlanilla(planillaForm, this.planillaActual.id,this.planillaActual.idSucursal).subscribe(response=>location.reload());
		}
		else{
			this.api.crearPlanilla(planillaForm).subscribe(response=>location.reload());
		}  

	}


	limpiarForm():void{
		this.planillaActual.id = null,
		this.planillaActual.cargo= null,
		this.planillaActual.mensual= null,
		this.planillaActual.hora= null,
		this.planillaActual.clase= null,
		this.planillaActual.idSucursal= null 

	}

}

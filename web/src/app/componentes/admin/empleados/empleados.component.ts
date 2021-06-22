import { Component, OnInit } from '@angular/core';

import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-empleados',
	templateUrl: './empleados.component.html',
	styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {

	constructor(private modalService: NgbModal, public api:AdminService) { }



	ngOnInit(): void {
		this.api.obtenerSucursales()
		.subscribe((response:any[])=> response.forEach(sucursal=>
			this.sucursalesDisponibles.push(sucursal.id)));
		
		this.obtenerEmpleados();
	}

	public empleados:any[];

	public actualizar:boolean;

	public closeResult: string;

	public planillasDisponibles:any[] = [];

	public sucursalesDisponibles:any[] = [];

	public empleadoActual = {
		cedula:null,
		email:null,
		nombre:null,
		apellido:null,
		provincia:null,
		canton:null,
		distrito:null,
		idPlanilla:null,
		cargo:null,
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

	obtenerEmpleados(){
		this.api.obtenerEmpleados()
		.subscribe((response:any[])=>{this.empleados = response});
	}


	crearNuevo(content){
		this.limpiarForm();
		this.actualizar = false;

		this.open(content);
	}

	actualizarEmpleado(content, empleado:any){

		this.empleadoActual = empleado;
		this.actualizar = true;
		this.open(content);
	}

	eliminarEmpleado(empleado:any){
		if (confirm('¿Está seguro que quiere eliminar el empleado?')){
			this.api.eliminarEmpleado(empleado)
			.subscribe(response=>location.reload());
		}
	}


	guardarEmpleado(empleadoForm: NgForm):void{

		this.modalService.dismissAll();


		if(this.actualizar){
			this.api.actualizarEmpleado(empleadoForm, this.empleadoActual.cedula).subscribe(response=>location.reload());
		}
		else{
			this.api.crearEmpleado(empleadoForm).subscribe(response=>location.reload());
		}  

	}


	limpiarForm():void{
		this.empleadoActual.cedula = null,
		this.empleadoActual.email= null,
		this.empleadoActual.nombre= null,
		this.empleadoActual.apellido = null,
		this.empleadoActual.provincia= null,
		this.empleadoActual.canton= null,
		this.empleadoActual.distrito = null,
		this.empleadoActual.idPlanilla= null,
		this.empleadoActual.cargo= null,
		this.empleadoActual.idSucursal= 0 
	}

	cargarPlanillasDisponibles(){	

		alert(this.empleadoActual.idSucursal);

		this.api.obtenerPlanillas()
		.subscribe((response:any[])=>{
			response.forEach(planilla=>{
				if(planilla.cedula=="" && planilla.idSucursal==this.empleadoActual.idSucursal){
					this.planillasDisponibles.push(planilla);
				}
			});
		});
	}
}

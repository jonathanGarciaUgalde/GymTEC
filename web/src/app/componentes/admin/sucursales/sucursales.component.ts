import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-sucursales',
	templateUrl: './sucursales.component.html',
	styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {

	constructor(private modalService: NgbModal, public api:AdminService) { }


	public sucursales:any[];

	public actualizar:boolean;

	public closeResult: string;

	public sucursalActual = {
		id: null,
		nombre: null,
		provincia: null,
		canton: null,
		distrito: null,
		tienda: null,
		capacidad: null,
		spa: null
	}

	telefonosActual:string = "";

	public telefonos:any[] =[];

	ngOnInit(): void {
		this.obtenerSucursales();
		console.log(this.telefonos);	
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


	obtenerSucursales(){
		this.api.obtenerSucursales()
		.subscribe((response:any[])=>{
			this.sucursales = response;
			this.obtenerTelefonos(response)});
	}


	crearNuevo(content){
		this.limpiarForm();
		this.actualizar = false;

		this.open(content);
	}

	actualizarSucursal(content, sucursal:any){

		this.telefonosActual = "";

		this.sucursalActual = sucursal;
		this.telefonos.forEach(telefono=>{
			if(telefono.id == sucursal.id){
				this.telefonosActual += telefono.tel + "\n";
			}
		})
		this.actualizar = true;
		this.open(content);
	}

	eliminarSucursal(sucursal:any){
		if (confirm('¿Está seguro que quiere eliminar la sucursal?')){
			this.api.eliminarSucursal(sucursal)
			.subscribe(response=>location.reload());
		}
	}


	guardarSucursal(sucursalForm: NgForm):void{

		this.modalService.dismissAll();


		if(this.actualizar){
			this.api.actualizarSucursal(sucursalForm, this.sucursalActual.id).subscribe(response=>location.reload());
		}
		else{
			this.api.crearSucursal(sucursalForm).subscribe(response=>location.reload());
		}  

	}

	activarTienda(sucursal:any){
		this.api.activarTienda(sucursal.id)
		.subscribe(response => {
			alert("Tienda activada");
			location.reload()
		});
	}

activarSpa(sucursal:any){
		this.api.activarSpa(sucursal.id)
		.subscribe(response => {
			alert("Spa activado");
			location.reload()
		});
	}

	//--Obtener telefonos de cada sucursal----

	obtenerTelefonos(sucursales){


		for (var i = 0; i < sucursales.length; i++) {
			this.api.obtenerTelefonos(sucursales[i].id)
			.subscribe((response:any[])=>{
				response.forEach(telefono=>this.telefonos.push({"tel": telefono.tel, "id": telefono.idSucursal}))
			});
		}


	}


	limpiarForm():void{
		this.sucursalActual.id = null,
		this.sucursalActual.nombre= null,
		this.sucursalActual.canton= null,
		this.sucursalActual.provincia= null,
		this.sucursalActual.distrito= null,
		this.sucursalActual.capacidad= null
	}
}

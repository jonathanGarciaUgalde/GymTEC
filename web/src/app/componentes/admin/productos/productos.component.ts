import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";

import {AdminService} from 'src/app/servicios/admin/admin.service';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {

  constructor(private modalService: NgbModal, public api:AdminService) { }

  ngOnInit(): void {
  	this.obtenerProductos();

  }

  	public productos:any[];

	public actualizar:boolean;

	public closeResult: string;

	public productoActual = {
		codigo:null,
		nombre:null,
		descripcion:null,
		costo:null,
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

	obtenerProductos(){
		this.api.obtenerProductos()
		.subscribe((response:any[])=>{this.productos = response});
	}


	crearNuevo(content){
		this.limpiarForm();
		this.actualizar = false;

		this.open(content);
	}

	actualizarProducto(content, producto:any){

		this.productoActual = producto;
		this.actualizar = true;
		this.open(content);
	}

	eliminarProducto(producto:any){
		if (confirm('¿Está seguro que quiere eliminar el producto?')){
			this.api.eliminarProducto(producto)
			.subscribe(response=>location.reload());
		}
	}


	guardarProducto(productoForm: NgForm):void{

		this.modalService.dismissAll();


		if(this.actualizar){
			this.api.actualizarProducto(productoForm, this.productoActual.codigo).subscribe(response=>location.reload());
		}
		else{
			this.api.crearProducto(productoForm).subscribe(response=>location.reload());
		}  

	}


	limpiarForm():void{
		this.productoActual.codigo = null,
		this.productoActual.nombre= null,
		this.productoActual.descripcion= null,
		this.productoActual.costo= null,
		this.productoActual.idSucursal= 0 
	}

}

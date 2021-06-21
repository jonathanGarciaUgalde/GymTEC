import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';

// Librerias para manejar Forms y Http
import { ReactiveFormsModule, FormsModule} from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';
import { NavbarClienteComponent } from './componentes/cliente/navbar-cliente/navbar-cliente.component';
import { BusquedaSucursalComponent } from './componentes/cliente/busqueda-sucursal/busqueda-sucursal.component';
import { BusquedaTipoClaseComponent } from './componentes/cliente/busqueda-tipo-clase/busqueda-tipo-clase.component';
import { BusquedaPeriodoComponent } from './componentes/cliente/busqueda-periodo/busqueda-periodo.component';

@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    NavbarClienteComponent,
    BusquedaSucursalComponent,
    BusquedaTipoClaseComponent,
    BusquedaPeriodoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, // Importa las rutas de los componentes
    ReactiveFormsModule, 
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

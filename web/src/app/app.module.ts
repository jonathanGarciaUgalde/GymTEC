import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http'; 

import {FormsModule} from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NabvarComponent } from './componentes/admin/nabvar/nabvar.component';
import { SucursalesComponent } from './componentes/admin/sucursales/sucursales.component';
import { LoginComponent } from './componentes/admin/login/login.component';
import { TratamientosComponent } from './componentes/admin/tratamientos/tratamientos.component';
import { PuestosComponent } from './componentes/admin/puestos/puestos.component';
import { PlanillasComponent } from './componentes/admin/planillas/planillas.component';
import { EmpleadosComponent } from './componentes/admin/empleados/empleados.component';
import { ServiciosComponent } from './componentes/admin/servicios/servicios.component';
import { EquipoComponent } from './componentes/admin/equipo/equipo.component';
import { InventarioComponent } from './componentes/admin/inventario/inventario.component';
import { ProductosComponent } from './componentes/admin/productos/productos.component';
import { GimnasioComponent } from './componentes/admin/gimnasio/gimnasio.component';
import { CalendarioComponent } from './componentes/admin/calendario/calendario.component';

@NgModule({
  declarations: [
    AppComponent,
    NabvarComponent,
    SucursalesComponent,
    LoginComponent,
    TratamientosComponent,
    PuestosComponent,
    PlanillasComponent,
    EmpleadosComponent,
    ServiciosComponent,
    EquipoComponent,
    InventarioComponent,
    ProductosComponent,
    GimnasioComponent,
    CalendarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

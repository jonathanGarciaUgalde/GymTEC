import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importar(injectar) componentes para manejar las rutas

import { LoginClienteComponent } from './componentes/cliente/login-cliente/login-cliente.component';
import { RegistrarComponent } from './componentes/cliente/registrar/registrar.component';
import { ActividadesProximasComponent } from './componentes/cliente/actividades-proximas/actividades-proximas.component';
import { BusquedaSucursalComponent } from './componentes/cliente/busqueda-sucursal/busqueda-sucursal.component';
import { BusquedaTipoClaseComponent } from './componentes/cliente/busqueda-tipo-clase/busqueda-tipo-clase.component';
import { BusquedaPeriodoComponent } from './componentes/cliente/busqueda-periodo/busqueda-periodo.component';

const routes: Routes = [
  {path: '', redirectTo:'login', pathMatch:'full'}, // ruta por defecto
  {path:'login', component:LoginClienteComponent},
  {path:'registrar', component:RegistrarComponent},
  {path:'actividades-proximas', component:ActividadesProximasComponent},
  {path:'busqueda-sucursal', component:BusquedaSucursalComponent},
  {path:'busqueda-tipo-clase', component:BusquedaTipoClaseComponent},
  {path:'busqueda-periodo', component:BusquedaPeriodoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// Exportar todos los componentes que estan en router
export const routingComponents = [LoginClienteComponent, RegistrarComponent, ActividadesProximasComponent, BusquedaSucursalComponent, BusquedaTipoClaseComponent, BusquedaPeriodoComponent]
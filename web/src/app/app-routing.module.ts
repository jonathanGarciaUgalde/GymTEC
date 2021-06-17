import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SucursalesComponent} from "./componentes/admin/sucursales/sucursales.component";
import {LoginComponent} from "./componentes/admin/login/login.component";
import { PuestosComponent } from './componentes/admin/puestos/puestos.component';
import { TratamientosComponent } from './componentes/admin/tratamientos/tratamientos.component';
import { PlanillasComponent } from './componentes/admin/planillas/planillas.component';
import { EmpleadosComponent } from './componentes/admin/empleados/empleados.component';
import { ServiciosComponent } from './componentes/admin/servicios/servicios.component';
import { EquipoComponent } from './componentes/admin/equipo/equipo.component';
import { InventarioComponent } from './componentes/admin/inventario/inventario.component';
import { ProductosComponent } from './componentes/admin/productos/productos.component';
import { GimnasioComponent } from './componentes/admin/gimnasio/gimnasio.component';
import { CalendarioComponent } from './componentes/admin/calendario/calendario.component';

const routes: Routes = [
{path:'admin', component: LoginComponent},
{path:'admin/sucursales', component: SucursalesComponent},
{path:'admin/tratamientos', component: TratamientosComponent},
{path:'admin/puestos', component: PuestosComponent},
{path:'admin/planillas', component: PlanillasComponent},
{path:'admin/empleados', component: EmpleadosComponent},
{path:'admin/servicios', component: ServiciosComponent},
{path:'admin/equipo', component: EquipoComponent},
{path:'admin/inventario', component: InventarioComponent},
{path:'admin/productos', component: ProductosComponent},
{path:'admin/gimnasio', component: GimnasioComponent},
{path:'admin/calendario', component: CalendarioComponent},
{path: '**', pathMatch:'full', redirectTo: ''}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

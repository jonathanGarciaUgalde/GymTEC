import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importar(injectar) componentes para manejar las rutas

import { LoginClienteComponent } from './componentes/cliente/login-cliente/login-cliente.component';
import { RegistrarComponent } from './componentes/cliente/registrar/registrar.component';
import { ActividadesProximasComponent } from './componentes/cliente/actividades-proximas/actividades-proximas.component';

const routes: Routes = [
  {path: '', redirectTo:'login', pathMatch:'full'}, // ruta por defecto
  {path:'login', component:LoginClienteComponent},
  {path:'registrar', component:RegistrarComponent},
  {path:'actividades-proximas', component:ActividadesProximasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// Exportar todos los componentes que estan en router
export const routingComponents = [LoginClienteComponent, RegistrarComponent, ActividadesProximasComponent]
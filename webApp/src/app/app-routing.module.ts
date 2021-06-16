import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importar(injectar) componentes para manejar las rutas

import { LoginClienteComponent } from './componentes/cliente/login-cliente/login-cliente.component';

const routes: Routes = [
  {path: '', redirectTo:'login', pathMatch:'full'}, // ruta por defecto
  {path:'login', component:LoginClienteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// Exportar todos los componentes que estan en router
export const routingComponents = [LoginClienteComponent]
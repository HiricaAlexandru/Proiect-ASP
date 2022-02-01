import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaMotoareComponent } from './lista-motoare/lista-motoare.component';
import { ModeleComponent } from './modele/modele.component';
import { MotorComponent } from './motor/motor.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'modele',
  },

  {
    path: 'modele',
    component: ModeleComponent
  },

  {
    path: 'lista-motoare',
    component: ListaMotoareComponent
  },

  {
    path:'motor',
    component:MotorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarsRoutingModule { }

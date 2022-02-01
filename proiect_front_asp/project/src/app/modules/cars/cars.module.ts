import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarsRoutingModule } from './cars-routing.module';
import { ModeleComponent } from './modele/modele.component';
import { ListaMotoareComponent } from './lista-motoare/lista-motoare.component';
import { MotorComponent } from './motor/motor.component';
import { MaterialModule } from '../material/material.module';


@NgModule({
  declarations: [
    ModeleComponent,
    ListaMotoareComponent,
    MotorComponent
  ],
  imports: [
    CommonModule,
    CarsRoutingModule,
    MaterialModule
  ]
})
export class CarsModule { }

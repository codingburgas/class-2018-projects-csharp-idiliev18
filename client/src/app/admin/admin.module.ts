import { NgModule } from '@angular/core';

import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { routes } from './admin-routing.module';
import { SensorsComponent } from './sensors/sensors.component';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';


@NgModule({
  declarations: [
    DashboardComponent,
    SensorsComponent,
    UsersComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  providers: []
})
export class AdminModule { }

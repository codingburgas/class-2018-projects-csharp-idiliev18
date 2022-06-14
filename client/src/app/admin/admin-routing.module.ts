import { SensorsComponent } from './sensors/sensors.component';
import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersComponent } from './users/users.component';

export const routes: Routes = [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'sensors', component: SensorsComponent},
    { path: 'users', component: UsersComponent}
];

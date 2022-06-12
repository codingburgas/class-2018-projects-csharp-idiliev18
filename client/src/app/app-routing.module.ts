import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { LoginFormComponent } from "./components/login-form/login-form.component";
import { RegisterFormComponent } from "./components/register-form/register-form.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { LandingComponent } from "./components/landing/landing.component";

const routes: Routes = [
  {
    path: "login",
    component: LoginFormComponent
  },
  {
    path: "register",
    component: RegisterFormComponent
  },
  {
    path: "dashboard",
    component: DashboardComponent
  },
  {
    path: "",
    component: LandingComponent
  },

  // otherwise redirect to home
  { path: "**", redirectTo: "" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}

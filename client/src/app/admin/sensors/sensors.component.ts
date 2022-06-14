import { lightSensor } from './../../models/lightSensor';
import { GardenService } from './../../services/garden.service';
import { humiditySensor } from './../../models/humiditySensor';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Role } from 'src/app/models/role';

@Component({
  selector: 'app-sensors',
  templateUrl: './sensors.component.html',
  styleUrls: ['./sensors.component.css']
})
export class SensorsComponent implements OnInit {

  public humiditySensors :humiditySensor[] = [];
  public lightSensors :lightSensor[] = [];
  constructor(private gd: GardenService, private authService:AuthService) {

  }
  get isAuthorized() {
    return this.authService.isAuthorized();
  }

  get isAdmin() {
    return this.authService.hasRole(Role.Admin);
  }

  get isGardener() {
    return this.authService.hasRole(Role.Gardener);
  }
  ngOnInit() {
    this.gd.getHumidutySensors().subscribe((hs) => {
      console.log(hs)
      this.humiditySensors = hs;

  });

  this.gd.getLightSensor().subscribe((ls) => {
    console.log(ls)
    this.lightSensors = ls;

});

  console.log("VUKA", this.humiditySensors)
}

}

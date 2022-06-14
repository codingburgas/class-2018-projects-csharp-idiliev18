import { lightSensor } from './../models/lightSensor';
import { Observable } from 'rxjs';
import { humiditySensor } from './../models/humiditySensor';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class GardenService {

  constructor(

    private http: HttpClient
    //private route: Router
    ) {}


    getHumidutySensors():Observable<humiditySensor[]>
    {
      console.log("VLIZA")
      let kokosh =  this.http.get<humiditySensor[]>("http://localhost:25825/api/MoistureSensor");
      console.log(kokosh)
      return kokosh
    }

    getLightSensor():Observable<lightSensor[]>
    {
      console.log("VLIZA")
      let kokosh =  this.http.get<lightSensor[]>("http://localhost:25825/api/LightSensor");
      console.log(kokosh)
      return kokosh
    }

    deleteEmployee(id: any): Observable<User[]>{
      return this.http.delete<User[]>(`http://localhost:25825/api/User` + `/${id}`);
}

    getUsers():Observable<User[]>
    {
      console.log("VLIZA")
      let kokosh =  this.http.get<User[]>("http://localhost:25825/api/User");
      console.log(kokosh)
      return kokosh
    }

}

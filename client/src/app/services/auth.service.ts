import { HttpClient, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Role } from '../models/role';
//import { Router } from '@angular/router';

@Injectable()
export class AuthService {
    private user: User;

    isAuthorized() {
        return !!this.user;
    }

    hasRole(role: Role) {
        return this.isAuthorized() && this.user.role === role;
    }

    constructor(

      private http: HttpClient
      //private route: Router
      ) {


          }


    login(username:string, password:string) {

      this.http.post<any>(`http://localhost:25825/api/User/Authenticate`, { username, password }).subscribe(res=>{

        this.user = {
          firstName: res.role[0].user.firstName,
          lastName : res.role[0].user.lastName,
          username: res.role[0].user.username,
          email : res.role[0].user.email,
          token : res.role[0].user.token,
          role : res.role[0].roleId
        }
        console.log(this.user)
      })


    }

    logout() {
      this.user = null;
    }
}

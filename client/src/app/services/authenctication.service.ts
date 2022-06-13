import { Router } from '@angular/router';
import { LocalStorageService } from './local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { User } from '../models/user';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  public user: Observable<User>;
  public isLoggedIn:boolean = false;

  constructor(
    private http: HttpClient,
    private localStorage: LocalStorageService,
    private route: Router
    ) {

    }

    login(username: string, password: string) : Observable<User> {
      console.log("KOLQ MISHKI")
      return this.http.post<any>(`http://localhost:3000/auth`, { username, password }).pipe(map(res => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        console.log(res)
        if(res.status == "success")
        {
          this.localStorage.writeToLocalStorage('user', JSON.stringify(res.token));
          this.isLoggedIn = true;
          this.user = res;
          this.route.navigate(['/dashboard']);
          return res;
        }
    }));
    }


    validateToken(token:string) : any{
      console.log("VALIDIRAM", token);
      this.http.post<any>(`http://localhost:25825/api/User/Validate/Request`, {  token }).pipe(map(res => {
        console.log(res);
        if(res.status == "success")
        {

          this.localStorage.writeToLocalStorage('user', JSON.stringify(res.token));
          this.isLoggedIn = true;
          this.user = res.info;
          return true;
        }

        return false;
      }));
    }











  //public get userValue(): User {
   // return this.userSubject.value;
//}

  logout():void {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
    //this.userSubject.next(null!);
    this.isLoggedIn = false;
    console.log('Logvai sa')

}

}

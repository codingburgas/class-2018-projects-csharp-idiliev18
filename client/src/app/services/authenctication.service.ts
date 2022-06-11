//import { LocalStorageService } from './local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { User } from '../interfaces/user';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  constructor(
    private http: HttpClient,
    //private localStorage: LocalStorageService
    ) {
     // this.userSubject = new BehaviorSubject<User>(JSON.parse("{toke:\"sdffdsdsfds\"}"));
     // this.user = this.userSubject.asObservable();
    }

    login(username: string, password: string) {
      console.log("KOLQ MISHKI")
      return this.http.post<any>(`http://localhost:3000/auth`, { username, password })
  }

  //public get userValue(): User {
   // return this.userSubject.value;
//}

  logout():void {
    // remove user from local storage to log user out
    //localStorage.removeItem('user');
    //this.userSubject.next(null!);
    console.log('Logvai sa')
    //this.router.navigate(['/login']);
}

}

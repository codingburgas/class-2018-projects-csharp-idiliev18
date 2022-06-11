import { LocalStorageService } from './local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from 'express';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { User } from '../interfaces/user';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(
    private router: Router,
    private http: HttpClient,
    private localStorage: LocalStorageService
    ) {
      this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.readFromLocalStorage('auth')));
      this.user = this.userSubject.asObservable();
    }

    login(username: string, password: string) {

      return this.http.post<any>(`http://localhost/auth`, { username, password })
          .pipe(map(user => {
              this.localStorage.writeToLocalStorage('auth', user.token)
              this.userSubject.next(user);
              return user;
          }));
  }

  public get userValue(): User {
    return this.userSubject.value;
}

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
    this.userSubject.next(null!);
    console.log('Logvai sa')
    //this.router.navigate(['/login']);
}

}

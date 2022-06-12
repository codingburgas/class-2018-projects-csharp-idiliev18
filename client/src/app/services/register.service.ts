import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiUrl = 'http://localhost:25825/api/User';

  constructor(private http: HttpClient) { }

  registerUser(user: any): Observable<User> {
    return this.http.post<User>(this.apiUrl, user);
  }

}

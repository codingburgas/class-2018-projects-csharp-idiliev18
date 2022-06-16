import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from '../models/role';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  Role = Role;
  public loginForm:any;

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.loginForm= new FormGroup({

      username: new FormControl('',[
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(64)
      ]),
      password: new FormControl('',[
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(64)
      ])
  }, { validators: Validators.required });
  }

  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  login(role: Role) {
    this.authService.login(this.username.value, this.password.value);
    this.router.navigate(['/']);
  }

  logout() {
    this.authService.logout();
  }
}

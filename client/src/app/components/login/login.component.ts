import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  public loginForm:any;


get username() { return this.loginForm.get('username'); }
get password() { return this.loginForm.get('password'); }

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
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

  qsha()
  {
    console.log(this.username.value);
    console.log(this.username.value);
    this.authenticationService.login(this.username.value, this.password.value)
                              .subscribe(vurnatGei=>console.log(vurnatGei));

  }

}

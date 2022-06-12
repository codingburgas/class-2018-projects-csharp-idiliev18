import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authenctication.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {


  public loginForm:any;


get username() { return this.loginForm.get('username'); }
get password() { return this.loginForm.get('password'); }

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {

console.log("JIV SAM")

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
    return (this.authenticationService.login(this.username.value, this.password.value)).subscribe(res=>console.log(res));


  }

}

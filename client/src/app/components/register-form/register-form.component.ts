import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { RegisterService } from './../../services/register.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})

export class RegisterFormComponent {

  registerForm = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(64)
      ]),
      lastName: new FormControl('',[
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(64)
      ]),
      email: new FormControl(''),
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

  get firstName() { return this.registerForm.get('firstName'); }
  get lastName() { return this.registerForm.get('lastName'); }
  get username() { return this.registerForm.get('username'); }
  get email() { return this.registerForm.get('email'); }
  get password() { return this.registerForm.get('password'); }

  users: User[] = [];

  constructor(private registerService: RegisterService) {}

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.log(this.registerForm.value);
    this.registerService.registerUser(this.registerForm.value).subscribe(user=>this.users.push(user));
    console.log(this.users);
  }
}














/*import { RegisterService } from './../../services/register.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/interfaces/user';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {



  constructor(private registerService: RegisterService) {}

  users: User[] = [];

  userData:User = {
    firstName: '',
    lastName: '',
    username: '',
    password: '',
  }



  createUser():void
  {
    console.log(this.userData);
    this.registerService.registerUser(this.userData).subscribe(user=>this.users.push(user));

    console.log(this.users);

  }



  ngOnInit(): void {
  }

}
*/

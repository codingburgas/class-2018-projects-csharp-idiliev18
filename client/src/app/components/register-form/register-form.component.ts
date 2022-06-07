import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})

export class RegisterFormComponent {

  registerForm = new FormGroup({
      firstName: new FormControl(['', Validators.required]),
      lastName: new FormControl(''),
      email: new FormControl(''),
      username: new FormControl(''),
      password: new FormControl('')
  });

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.log(this.registerForm.value);
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
import { RegisterService } from './../../services/register.service';
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
    id: 1,
    firstName: '',
    lastName: '',
    username: '',
    PasswordHash: '',
    Salt: ''
  }

  ngOnInit(): void {
  }

  createUser():void
  {
    console.log(this.userData);
    //this.registerService.registerUser(this.userData).subscribe(user=>this.users.push(user));

    console.log(this.users);

  }

}

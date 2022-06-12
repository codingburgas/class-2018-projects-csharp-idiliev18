import { AuthenticationService } from 'src/app/services/authenctication.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  public kondio:boolean = true;
  public isAuthenticated:boolean = false;


  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {

    this.isAuthenticated = this.authenticationService.isLoggedIn;
  }

}

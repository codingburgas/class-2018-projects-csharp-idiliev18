import { AuthenticationService } from 'src/app/services/authenctication.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
              private route: Router) { }

  ngOnInit(): void {
    if(this.authenticationService.isLoggedIn == false)
    {
      this.route.navigate(['/']);
    }
  }

}

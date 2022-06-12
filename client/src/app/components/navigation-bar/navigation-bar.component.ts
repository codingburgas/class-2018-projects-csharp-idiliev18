import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authenctication.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {



  constructor(public authenticationService: AuthenticationService) { }


  ngOnInit() {
    if(this.authenticationService.isLoggedIn)
    {
      console.log(this.authenticationService.user);
    }
  }

  logout()
  {
    this.authenticationService.logout();
  }

}

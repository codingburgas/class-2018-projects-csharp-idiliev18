import { LocalStorageService } from './../../services/local-storage.service';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authenctication.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {



  constructor(public authenticationService: AuthenticationService, public localStorageService: LocalStorageService) { }


  ngOnInit() {

  }

  isAuthenticated():boolean
  {
    console.log("kkkkkkk")
    var r = this.authenticationService.validateToken(this.localStorageService.readFromLocalStorage("user"));
    console.log(r)
    return  r;
  }

  logout()
  {
    this.authenticationService.logout();
  }

}

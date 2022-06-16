import { User } from './../../models/user';
import { Component, OnInit } from '@angular/core';
import { GardenService } from 'src/app/services/garden.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: User[] = [];

  header = {
      id: 'Id↑', //↑
      firstName: 'First name',
      lastName: 'Last name',
      username: "Username",
      email: "Email",
      sort: "id",
      order: '↑'
  };

  constructor(private userService: GardenService) {}

  sortEmployees(field: string) {

      // Checks if there are elements in the array
      if (this.users.length == 0) {
          return;
      }

      if (this.header.sort != field) {
          this.header.order = '↓';
      }

      let e = this.users[0] as any;

      (this.header as any)[this.header.sort] = (this.header as any)[this.header.sort].slice(0, -1);
      this.header.sort = field;

      if (typeof e[field] === 'string') {
          if (this.header.order == '↑') {
              this.users.sort((a, b) =>
                  (b as any)[field].localeCompare((a as any)[field])
              );

              this.header.order = '↓';
          } else {
              this.users.sort((a, b) =>
                  (a as any)[field].localeCompare((b as any)[field])
              );

              this.header.order = '↑';
          }
      } else {
          if (this.header.order == '↑') {
              this.users.sort(
                  (a, b) => (b as any)[field] - (a as any)[field]
              );
              this.header.order = '↓';
          } else {
              this.users.sort(
                  (a, b) => (a as any)[field] - (b as any)[field]
              );
              this.header.order = '↑';
          }
      }

      (this.header as any)[field] = (this.header as any)[field] + this.header.order;
  }

  deleteEmployee(id: any) {
    this.userService.deleteEmployee(id).subscribe();
    this.users = this.users.filter((value) => {
        return value.id != id;
    });
  }

  deleteAllEmployees(){

  }

  ngOnInit(): void {
      this.userService.getUsers().subscribe((users) => {
          this.users = users;
      });
  }
}

import { Component } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-fetch-user',
  templateUrl: './fetch-user.component.html',
  styleUrls: ['./fetch-user.component.css']
})
export class FetchUserComponent {
  public users: User[];
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.userService
      .getUsers()
      .subscribe((data) => {
        if (data.status == 200) {
          console.info(data.message);
          console.info(data.list);
          this.users = data.list;
        }
        else {
          alert(data.message);
        }
      }, (error) => alert(error));
  }

  deleteUser(userId: number): void {
    const res = confirm("Do you really want to delete user with Id: " + userId);
    if (res) {
      this.userService
        .deleteUser(userId)
        .subscribe(
          (data) => {
          if (data.status == 200) {
            alert(data.message)
            this.getUsers();
          }
          else {
            alert(data.message)
          }
        },
          (error) => alert(error)
        );
    }
  }

  

}

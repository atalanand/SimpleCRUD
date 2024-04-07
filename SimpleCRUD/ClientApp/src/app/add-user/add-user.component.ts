import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { State } from '../models/state';
import { Role } from '../models/role';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  userForm: FormGroup;
  title = 'Add User';
  id: number;
  errorMessage: any;
  states: State[];
  roles: Role[];
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private avRoute: ActivatedRoute,
    private userService: UserService,
    private router: Router
  ) {
    if (this.avRoute.snapshot.params.id) {
      this.id = this.avRoute.snapshot.params.id;
    }

    this.userForm = this.fb.group(
      {
        id: 0,
        name: ['', [Validators.required, Validators.minLength(3)]],
        address: ['', [Validators.required, Validators.minLength(10)]],
        roleId: ['', [Validators.required]],
        stateId: ['', [Validators.required]]
      }
    );
  }

  ngOnInit(): void {
    this.getStates();
    this.getRoles();

    if (this.id > 0) {
      this.title = 'Update User';

      this.userService.getUserDetail(this.id).subscribe(
        (data) => {
          if (data.status == 200) {
            console.info(data.message);
            console.info(data.object);
            this.userForm.setValue(data.object);
          }
          else {
            alert(data.message);
            this.router.navigate(['users']);           
          }
        },
        (error) => console.error(error)
      );
    }
  }

  get registerFormControl() {
    return this.userForm.controls;
  }

  private addUser(): void {
    this.userService.addUser(this.userForm.value).subscribe(
      (data) => {
        if (data.status == 200) {
          alert(data.message)
          this.router.navigate(['users']);
        }
        else {
          alert(data.message)
        }
      },
      (error) => alert(error)
    );
  }

  private updateUser(): void {
    this.userService.updateUser(this.userForm.value).subscribe(
      (data) => {
        if (data.status == 200) {
          alert(data.message)
          this.router.navigate(['users']);
        }
        else {
          alert(data.message)
        }
      },
      (error) => alert(error)
    );
  }

  save(): void {
    this.submitted = true;
    this.userForm.controls['name'].setValue(this.userForm.controls['name'].value.trim());
    this.userForm.controls['address'].setValue(this.userForm.controls['address'].value.trim());
    if (!this.userForm.valid) {
      return;
    }
    if (this.title == 'Add User') {
      this.addUser();
    }
    else if (this.title == 'Update User') {
      this.updateUser();
    }
  }

  private getStates(): void {
    this.userService.getStates().subscribe(
      (data) => {
        if (data.status == 200) {
          console.info(data.message);
          console.info(data.list);
          this.states = data.list;
        }
        else {
          alert(data.message)
        }
      }, (error) => alert(error)
    );
  }

  private getRoles(): void {
    this.userService.getRoles().subscribe(
      (data) => {
        if (data.status == 200) {
          console.info(data.message);
          console.info(data.list);
          this.roles = data.list;
        }
        else {
          alert(data.message)
        }
      }, (error) => alert(error)
    );
  }

  public cancel(): void {
    this.router.navigate(['users']);
  }

}

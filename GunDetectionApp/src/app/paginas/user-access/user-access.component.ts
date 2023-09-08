import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { from } from 'rxjs';
import { User } from '../../Models/user';
import { SubUsersService } from '../../Services/sub-users.service';
import { DeleteComponent } from '../modals/delete/delete.component';
import { UserAccessModalComponent } from '../modals/user-access-modal/user-access-modal.component';

@Component({
  selector: 'app-user-access',
  templateUrl: './user-access.component.html',
  styleUrls: ['./user-access.component.css']
})
export class UserAccessComponent implements OnInit {
  listUsers: User[];
  constructor(public dialog: MatDialog, private SubUserService: SubUsersService, private router:Router) { }

  ngOnInit(): void {
    let idUser = sessionStorage.getItem("user");
    this.SubUserService.GetUsersAccess(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x),error => console.log(error))
  }
  Confirm(x: any): void {
    this.listUsers = x;
  }

  CreateUserAccess() {
    const dia = this.dialog.open(UserAccessModalComponent, {
      data: {
        tit: "Create User Access App",
       
        key: "CreateUserAccessApp"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        let idUser = sessionStorage.getItem("user");
        this.listUsers = null;
        this.SubUserService.GetUsersAccess(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }


  Delete(li: User) {
    const dia = this.dialog.open(DeleteComponent, {
      data: {
        tit: "Delete User Access App",
        msg: "The " + li.name + " User Access App will be removed",
        loca: li,
        key: "UserAccessApp"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listUsers = null;
        let idUser = sessionStorage.getItem("user");
        this.SubUserService.GetUsersAccess(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Update(li: User) {

    const dia = this.dialog.open(UserAccessModalComponent, {
      data: {
        tit: "Update User Access App",
        user:li,
        key: "UpdateUserAccessApp"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        let idUser = sessionStorage.getItem("user");
        this.listUsers = null;
        this.SubUserService.GetUsersAccess(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Back() {
    this.router.navigate(["Home/User"]);
  }

}

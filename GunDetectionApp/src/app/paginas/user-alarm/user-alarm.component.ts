import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { UserAlarm } from '../../Models/user-alarm';
import { SubUsersService } from '../../Services/sub-users.service';
import { DeleteComponent } from '../modals/delete/delete.component';
import { UserAccessModalComponent } from '../modals/user-access-modal/user-access-modal.component';

@Component({
  selector: 'app-user-alarm',
  templateUrl: './user-alarm.component.html',
  styleUrls: ['./user-alarm.component.css']
})
export class UserAlarmComponent implements OnInit {

  listUsers: UserAlarm[];
  constructor(public dialog: MatDialog, private SubUserService: SubUsersService,private router: Router) { }

  ngOnInit(): void {
    let idUser = sessionStorage.getItem("user");
    this.SubUserService.GetUsersAlarm(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))
  }
  Confirm(x: any): void {
    this.listUsers = x;
    
  }

  CreateUserAccess() {
    const dia = this.dialog.open(UserAccessModalComponent, {
      data: {
        tit: "Create User Alarm",

        key: "CreateUserAlarm"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        let idUser = sessionStorage.getItem("user");
        this.listUsers = null;
        this.SubUserService.GetUsersAlarm(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }


  Delete(li: UserAlarm) {
    const dia = this.dialog.open(DeleteComponent, {
      data: {
        tit: "Delete User Alarm ",
        msg: "The " + li.name + " User Alarm will be removed",
        loca: li,
        key: "UserAlarm"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listUsers = null;
        let idUser = sessionStorage.getItem("user");
        this.SubUserService.GetUsersAlarm(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Update(li: UserAlarm) {

    const dia = this.dialog.open(UserAccessModalComponent, {
      data: {
        tit: "Update User Alarm",
        user: li,
        key: "UpdateUserAlarm"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        let idUser = sessionStorage.getItem("user");
        this.listUsers = null;
        this.SubUserService.GetUsersAlarm(Guid.parse(idUser)["value"]).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Back() {
    this.router.navigate(["Home/User"]);
  }
}

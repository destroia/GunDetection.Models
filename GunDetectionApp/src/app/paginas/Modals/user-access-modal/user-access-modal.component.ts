import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { User } from '../../../Models/user';
import { UserAlarm } from '../../../Models/user-alarm';
import { SubUsersService } from '../../../Services/sub-users.service';

@Component({
  selector: 'app-user-access-modal',
  templateUrl: './user-access-modal.component.html',
  styleUrls: ['./user-access-modal.component.css']
})
export class UserAccessModalComponent implements OnInit {

  activateSave: boolean = true;
  checkBoxAlert: boolean = false;
  formularioUser: FormGroup;
  constructor(public dialogRef: MatDialogRef<UserAccessModalComponent>, private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any, private SubUserService: SubUsersService) { }

  ngOnInit(): void {
    this.InitFormulario();
    if (this.data.key == "CreateUserAlarm" || this.data.key == "UpdateUserAlarm") {
      this.checkBoxAlert = true;
    }
    if (this.data.key == "UpdateUserAccessApp" || this.data.key == "UpdateUserAlarm") {
      this.formularioUser.controls["email"].setValue(this.data.user.email);
      this.formularioUser.controls["name"].setValue(this.data.user.name);
      this.formularioUser.controls["lastName"].setValue(this.data.user.lastName);
      this.formularioUser.controls["phone"].setValue(this.data.user.phone);

      this.formularioUser.controls["checkFight"].setValue(this.data.user.figth);
      this.formularioUser.controls["checkHand"].setValue(this.data.user.handsUp);
      this.formularioUser.controls["checkGun"].setValue(this.data.user.gunDetected);
      this.formularioUser.controls["checkPerson"].setValue(this.data.user.personDetection);

    }
  }
  InitFormulario() {
    this.formularioUser = this.fb.group(
      {

        name: ["", Validators.required],
        lastName: ["", Validators.required],
        email: ["", Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])],
        phone: ["", Validators.compose([
          Validators.required,
          Validators.minLength(10)])
        ],
        checkGun: [],
        checkPerson: [],
        checkHand: [],
        checkFight: []

      });
  }
  Save() {

    this.activateSave = false;
    if (this.data.key == "CreateUserAccessApp") {
      let u: User = new User();
      let idUser = sessionStorage.getItem("user");

      u.account = idUser;
      u.id = Guid.create()["value"];
      u.email = this.formularioUser.controls["email"].value;
      u.name =  this.formularioUser.controls["name"].value;
      u.lastName = this.formularioUser.controls["lastName"].value;
      u.phone = this.formularioUser.controls["phone"].value;

      this.SubUserService.CreateAccess(u).subscribe(x => this.Confirm(x), error => console.log(error));
      
    }

    if (this.data.key == "UpdateUserAccessApp") {
      let u: User = this.data.user;

      u.email = this.formularioUser.controls["email"].value;
      u.name = this.formularioUser.controls["name"].value;
      u.lastName = this.formularioUser.controls["lastName"].value;
      u.phone = this.formularioUser.controls["phone"].value;

      this.SubUserService.UpdateAccess(u).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "UpdateUserAlarm") {
      let u: UserAlarm = this.data.user;

      u.email = this.formularioUser.controls["email"].value;
      u.name = this.formularioUser.controls["name"].value;
      u.lastName = this.formularioUser.controls["lastName"].value;
      u.phone = this.formularioUser.controls["phone"].value;

      u.figth = this.formularioUser.controls["checkFight"].value;
      u.handsUp = this.formularioUser.controls["checkHand"].value;
      u.gunDetected = this.formularioUser.controls["checkGun"].value;
      u.personDetection = this.formularioUser.controls["checkPerson"].value;

      this.SubUserService.UpdateAlarm(u).subscribe(x => this.Confirm(x), error => console.log(error));
    }

    if (this.data.key == "CreateUserAlarm") {
      let u: UserAlarm = new UserAlarm();
      let idUser = sessionStorage.getItem("user");

      u.idAccount = Guid.parse(idUser)["value"];
      u.id = Guid.create()["value"];
      u.email = this.formularioUser.controls["email"].value;
      u.name = this.formularioUser.controls["name"].value;
      u.lastName = this.formularioUser.controls["lastName"].value;
      u.phone = this.formularioUser.controls["phone"].value;

      u.figth = this.formularioUser.controls["checkFight"].value;
      u.handsUp = this.formularioUser.controls["checkHand"].value;
      u.gunDetected = this.formularioUser.controls["checkGun"].value;
      u.personDetection = this.formularioUser.controls["checkPerson"].value;

      this.SubUserService.CreateAlarm(u).subscribe(x => this.Confirm(x), error => console.log(error));

    }
  }
    Confirm(x: any): void {
      if (x.statusCode == 200) {
        this.dialogRef.close(true);
        return;
      }
      this.activateSave = true;
  }

  OnClick() {
    this.dialogRef.close(false);
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { User } from '../../Models/user';
import { SubUsersService } from '../../Services/sub-users.service';
import { UserService } from '../../Services/user.service';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  formularioUser: FormGroup;
  activateSave: boolean = true;
  user: User;
  constructor(private router: Router, private fb: FormBuilder, private userService: UserService, private subUserService: SubUsersService) { }

  ngOnInit(): void {
    this.InitFormulario();
    this.userService.GetById(Guid.parse(sessionStorage.getItem("id"))["value"]).subscribe(x => this.ConfirmGet(x), error => console.log(error));
  }
  ConfirmGet(x: User): void {
    this.user = x;
    
    this.formularioUser.controls["name"].setValue(this.user.name);
    this.formularioUser.controls["lastName"].setValue(this.user.lastName);
    this.formularioUser.controls["email"].setValue(this.user.email);
    this.formularioUser.controls["phone"].setValue(this.user.phone);
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
        ]

      });
  }
  UserAlerts() {
    this.router.navigate(["Home/UserAlarm"]);
  
  }

  UserAccess() {
    this.router.navigate(["Home/UserAccessApp"]);
  }
  Save() {
    this.activateSave = false;
    this.user.name = this.formularioUser.controls["name"].value;
    this.user.lastName = this.formularioUser.controls["lastName"].value;
    this.user.email =  this.formularioUser.controls["email"].value;
    this.user.phone = this.formularioUser.controls["phone"].value;

    this.subUserService.UpdateAccess(this.user).subscribe(x => this.ConfirmUpdate(x), error => console.log(error));

  }
  ConfirmUpdate(x: any): void {
    if (x.statusCode == 200) {
      this.activateSave = true;
    }
    }
}

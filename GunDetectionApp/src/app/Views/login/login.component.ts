import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../../Models/login';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formularioLogin: FormGroup;
  showLoginFail: boolean = false;
  loader: boolean = false;
  textPassword: string = "password";
  constructor(private fb: FormBuilder,private ServiceUser : UserService,private route:Router) { }
  loginFalse: boolean = false;
  ngOnInit(): void {
    try {
      let u = localStorage.getItem("user")
      if (u == null) {
        this.route.navigate(["Home"]);
        return;
      }

    } catch (e) {

    }
    this.InitFormulario();
  }
  InitFormulario() {
    this.formularioLogin = this.fb.group(
      {
       
        mail: ["", Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])],
        password: ["", Validators.compose([
          Validators.required,
          Validators.minLength(8)])
          ],
        check: [true],
        //checkPassword:[]
      });
  }
  ShowPassword() {
    if (this.textPassword == "password") {
      this.textPassword = "text";
    } else {
      this.textPassword = "password"
    }
    console.log("changed")
  }
  Login() {
    this.route.navigate(["Home"]);
    this.loginFalse = false;
    this.showLoginFail = false;
    let l: Login = new Login();
    l.mail = this.formularioLogin.controls['mail'].value;
    l.password = this.formularioLogin.controls['password'].value;
    this.loader = true;
    this.ServiceUser.Login(l).subscribe(x => { this.ConfirmacionLogin(x) }, error => { this.showLoginFail = true, this.loader = false; } );
      
  }
    ConfirmacionLogin(x: any) {
      if (x.res == true) {
        this.loader = false;
        sessionStorage.setItem("user", x.user.account);
        sessionStorage.setItem("id", x.user.id);
        if (this.formularioLogin.controls['check'].value == true) {
          localStorage.setItem("id", x.user.id);
          localStorage.setItem("user", x.user.account);
        }
        this.route.navigate(["Home"]);

      }
      else {
        this.loader = false;
        this.showLoginFail = true;
        this.loginFalse = true;
      }
  }

  SignIn() {
    this.route.navigate(["SignIn"]);
  }
  LostPassword() {
    this.route.navigate(["LostPassword"]);
  }
}

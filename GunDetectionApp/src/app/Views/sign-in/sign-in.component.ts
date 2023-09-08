import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  showMsgEmailExis: boolean = false;
  showSendMail: boolean = false;
  showError: boolean = false;
  showBtnSignIn: boolean = true;
  formularioSignIn: FormGroup;
  constructor(private fb: FormBuilder, private ServiceUser: UserService, private route: Router) { }
  ngOnInit(): void {
    this.InitFormulario();
  }

  LostPassword() {
    this.route.navigate(["LostPassword"])
  }

  InitFormulario() {
    this.formularioSignIn = this.fb.group(
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
        password: ["", Validators.compose([
          Validators.required,
          Validators.minLength(8)])
        ],
        confirmPassword: ["", Validators.compose([
          Validators.required,
          Validators.minLength(8)])
        ]

      }, { validator: RepeatPasswordValidator }
    );
  }
  SignIn() {
    this.showBtnSignIn = false;
    this.showError = false;
    this.showSendMail = false;
    this.showMsgEmailExis = false;
    this.ServiceUser.SignIn(this.formularioSignIn.value).subscribe(x =>
    { this.ConfirmSignIn(x) }, error => console.log(error));
  }
  ConfirmSignIn(x: any) {
      console.log(x)
      if (x.res == 1) {
        this.showSendMail = true;;
        return;
      } else if (x.res == 2 ) {
        this.showMsgEmailExis = true;
        return;
    }

      this.showError = true;
  }

  Back() {
    this.route.navigate(["Login"]);
  }
}
export function RepeatPasswordValidator(group: FormGroup) {
  let password = group.controls.password.value;
  let confirmPassword = group.controls.confirmPassword.value;

  return password === confirmPassword ? null : { passwordsNotEqual: true }
}

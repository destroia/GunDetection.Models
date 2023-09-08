import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-create-pasword',
  templateUrl: './create-pasword.component.html',
  styleUrls: ['./create-pasword.component.css']
})
export class CreatePaswordComponent implements OnInit {

  idU: string;
  formularioCreatePassword: FormGroup;
  constructor(private fb: FormBuilder, private ServiceUser: UserService, private route: Router,private activateRoute : ActivatedRoute) { }

  ngOnInit(): void {
    this.activateRoute.queryParams.subscribe(param =>
      this.idU = param['Id']);
   
    this.InitFormulario();
  }
  passwordsMatcher = new RepeatPasswordEStateMatcher;
  InitFormulario() {
    this.formularioCreatePassword = this.fb.group(
      {

        confirmPassword: ["", Validators.compose([
          Validators.required,
          Validators.minLength(8)
        ])],
        password: ["", Validators.compose([
          Validators.required,
          Validators.minLength(8)])
        ]
      }, { validator: RepeatPasswordValidator });
    
  }
  
  CreatePassword() {
    let pass = this.formularioCreatePassword.controls['password'].value;
    let confirmPass = this.formularioCreatePassword.controls['confirmPassword'].value;

    
    if (pass == confirmPass && this.formularioCreatePassword.valid) {
      let Creat: CreatePassword = new CreatePassword();
      Creat.password = confirmPass;
      Creat.idUser = this.idU;
      this.ServiceUser.CreatePassword(Creat).subscribe(
        x => { this.ConfirmCreatePasword(x) },
        error => console.log(error));
    }
    else {
      alert("Do not consider the password with your confirmation");
    }
  }
  ConfirmCreatePasword(x: any) {
    console.log(x)
    if (x.res) {
      this.route.navigate(['Login']);
    }
    else {
      alert("")
    }
    }
}

import { ErrorStateMatcher } from '@angular/material/core';
import { CreatePassword } from '../../Models/create-password';

export const EmailValidation = [Validators.required, Validators.email];
export const PasswordValidation = [
  Validators.required,
  Validators.minLength(6),
  Validators.maxLength(24),
];

export class RepeatPasswordEStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    return (control && control.parent.get('password').value !== control.parent.get('confirmPassword').value && control.dirty)
  }
}
export function RepeatPasswordValidator(group: FormGroup) {
  let password = group.controls.password.value;
  let confirmPassword = group.controls.confirmPassword.value;

  return password === confirmPassword ? null : { passwordsNotEqual: true }
}

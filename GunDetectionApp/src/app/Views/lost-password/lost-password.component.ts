import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-lost-password',
  templateUrl: './lost-password.component.html',
  styleUrls: ['./lost-password.component.css']
})
export class LostPasswordComponent implements OnInit {
  showSendMail: boolean = true;
  formularioLostPassword: FormGroup;
  constructor(private fb: FormBuilder, private ServiceUser: UserService, private route: Router) { }

  ngOnInit(): void {
    this.InitFormulario();
  }
  InitFormulario() {
    this.formularioLostPassword = this.fb.group(
      {
        email: ["", Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])]
      });
  }

  Send() {
    this.ServiceUser.LostPasword(this.formularioLostPassword.controls['email'].value)
      .subscribe(x => { this.ConfirmMail(x) }, error => console.log(error));
  }
    ConfirmMail(x: any) {
      console.log(x);
      this.showSendMail = false;
     
  }

  Back() {
    this.route.navigate(["Login"])
  }
}

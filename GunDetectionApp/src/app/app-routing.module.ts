import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AlertComponent } from './Views/alert/alert.component';
import { CreatePaswordComponent } from './views/create-pasword/create-pasword.component';
import { LoginComponent } from './Views/login/login.component';
import { LostPasswordComponent } from './views/lost-password/lost-password.component';
import { SignInComponent } from './views/sign-in/sign-in.component';
import { StreamingComponent } from './views/streaming/streaming.component';
import { ValidateComponent } from './Views/validate/validate.component';


const routes: Routes =
  [
    { path: "", component: LoginComponent },
    { path: "Login", component: LoginComponent },
    { path: "SignIn", component: SignInComponent },
    { path: "LostPassword", component: LostPasswordComponent },
    { path: "CreatePassword", component: CreatePaswordComponent },
    { path: "Validate", component: ValidateComponent },
    { path: "Alert", component: AlertComponent }, 
    { path: "Streaming", component: StreamingComponent }
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

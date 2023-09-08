import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-validate',
  templateUrl: './validate.component.html',
  styleUrls: ['./validate.component.css']
})
export class ValidateComponent implements OnInit {
  id: string;
  Error: boolean = false;
  Validacion: boolean = false;
  constructor( private ServiceUser: UserService, private route: Router, private activateRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.activateRoute.queryParams.subscribe(param =>
      this.id = param["Id"]);
    if (this.id != null) {
      this.ServiceUser.Validate(this.id).subscribe(x => { this.ConfirmValidate(x) }, error => console.log(error));
    } else {
      this.Error = true;
    }
   
  }
    ConfirmValidate(x: any) {
      if (x.res) {
        this.Validacion = true
      } else {
        this.Error = true;
      }
    }
  SignIn() {
    this.route.navigate(["Login"])
  }
}

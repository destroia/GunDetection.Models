import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Location, SubLocation } from '../../../Models/location';
import { LocationService } from '../../../Services/location.service';

@Component({
  selector: 'app-create-location',
  templateUrl: './create-location.component.html',
  styleUrls: ['./create-location.component.css']
})
export class CreateLocationComponent implements OnInit {
  formularioCreateLocation: FormGroup;
  activateSave: boolean = true;
  error: boolean = false;
  constructor(private fb: FormBuilder, private router: Router, private locaServices: LocationService,
    public dialogRef: MatDialogRef<CreateLocationComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { this.InitFormulario(); }

  ngOnInit(): void {
    
  }
  InitFormulario() {
    this.formularioCreateLocation = this.fb.group(
      {

        name: ["", Validators.required ],
        phone: [""],
        mailAddress: [""],
        observation : [""]
      });
  }
  Save() {

    this.activateSave = false;

    if (this.formularioCreateLocation.controls['name'].valid) {
      let idU = sessionStorage.getItem("user");
      if (idU == null || idU == Guid.EMPTY) {
        this.router.navigate(["Login"]);
      }

      if (this.data.key == "location") {
        let loca: Location = new Location();
        loca.id = Guid.create()["value"];

        loca.idUser = Guid.parse(idU)["value"];
        loca.name = this.formularioCreateLocation.controls['name'].value;

       
        this.locaServices.CreateLocation(loca).subscribe(x => this.Confirm(x), error => this.error = true)
      }
      if (this.data.key == "sublocation") {
      
        let subloca: SubLocation = new SubLocation();

        subloca.id = Guid.create()["value"];
        subloca.idLocation = this.data.idLoca;
        subloca.name = this.formularioCreateLocation.controls['name'].value;

        this.locaServices.CreateSubLocation(subloca).subscribe(x => this.Confirm(x), error => console.log(error));
      }
     
    }
  }
  Confirm(x: any) {
    console.log(x)
    if (x.statusCode == 200) {
      this.dialogRef.close(true);
    }
    else {
      this.error = true;
      this.activateSave = true;
       }
    }
}

import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location, SubLocation } from '../../../Models/location';
import { LocationService } from '../../../Services/location.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  formularioUpdate: FormGroup;
  activateSave: boolean = true;
  constructor(public dialogRef: MatDialogRef<UpdateComponent>, private fb: FormBuilder ,private locaService: LocationService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.InitFormulario();
    if (this.data.key == "location") {
      this.formularioUpdate.controls['name'].setValue(this.data.loca.name);
    }
    if (this.data.key == "sublocation") {
      this.formularioUpdate.controls['name'].setValue(this.data.subloca.name);
    }
  }
  OnClick() {
    this.dialogRef.close(false);
  }
  InitFormulario() {
    this.formularioUpdate = this.fb.group(
      {

        name: ["", Validators.required]

      });
  }
  Update() {
    this.activateSave = false;
    if (this.data.key =="location") {
      let l: Location = this.data.loca;
      l.name = this.formularioUpdate.controls['name'].value;
      this.locaService.UpdateLocation(l).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "sublocation") {
      let l: SubLocation = this.data.subloca;
      l.name = this.formularioUpdate.controls['name'].value;
      this.locaService.UpdateSubLocation(l).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    
  }
  Confirm(x: any): void {
    
    if (x.statusCode == 200) {
      this.dialogRef.close(true);
      return;
    } else {
      this.activateSave = true;
    }
    }
}

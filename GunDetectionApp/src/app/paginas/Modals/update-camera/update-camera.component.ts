import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Camera } from '../../../Models/camera';
import { Location, SubLocation } from '../../../Models/location';
import { CameraService } from '../../../Services/camera.service';
import { LocationService } from '../../../Services/location.service';

@Component({
  selector: 'app-update-camera',
  templateUrl: './update-camera.component.html',
  styleUrls: ['./update-camera.component.css']
})
export class UpdateCameraComponent implements OnInit {
  saveShow: boolean = true;
  formularioCreateCamera: FormGroup;
  listLoca: Location[];
  listSubLoca: SubLocation[];
  constructor(public dialogRef: MatDialogRef<UpdateCameraComponent>, private fb: FormBuilder, private locaService: LocationService,
    private cameraService: CameraService,   @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.InitFormulario();
    var idUser = sessionStorage.getItem("user");
    this.locaService.GetLocations(idUser).subscribe(x => this.ConfirmLoca(x), error => console.log(error));
    this.formularioCreateCamera.controls["name"].setValue(this.data.cam.name);
    this.formularioCreateCamera.controls["location"].setValue(this.data.cam.idLocation);
    this.formularioCreateCamera.controls["sublocation"].setValue(this.data.cam.idSubLocation);

  }
  InitFormulario() {
    this.formularioCreateCamera = this.fb.group(
      {

        name: ["", Validators.required],
        location: ["", Validators.required],
        sublocation: ["", Validators.required],

      });
  }
  ConfirmLoca(x: Location[]): void {
    if (x.length != 0) {
      this.listLoca = x;

    }
    this.ChangeLocation();
  }
  ChangeLocation() {
    this.locaService.GetSubLocations(this.formularioCreateCamera.controls["location"].value)
      .subscribe(x => this.ConfirmSubLocations(x), error => console.log(error));
  }
  ConfirmSubLocations(x: SubLocation[]): void {
    this.listSubLoca = x;
  }
  Save() {
    this.saveShow = false;
    let c: Camera = new Camera();
    c.id = this.data.cam.id;
    c.idLocation = this.formularioCreateCamera.controls["location"].value;
    c.idSubLocation = this.formularioCreateCamera.controls["sublocation"].value;
    c.idUser = this.data.cam.idUser;
    c.name = this.formularioCreateCamera.controls["name"].value;
   

    this.cameraService.Update(c).subscribe(x => this.ConfirmCamare(x), error => console.log(error));
  }
    ConfirmCamare(x: any): void {
      if (x.statusCode == 200) {
        this.dialogRef.close(true);
      }
      this.saveShow = true;
  }
  OnClick() {
    this.dialogRef.close(false);
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Camera } from '../../Models/camera';
import { Location, SubLocation } from '../../Models/location';
import { CameraService } from '../../Services/camera.service';
import { LocationService } from '../../Services/location.service';
import { CreateLocationComponent } from '../modals/create-location/create-location.component';

@Component({
  selector: 'app-create-camera',
  templateUrl: './create-camera.component.html',
  styleUrls: ['./create-camera.component.css']
})
export class CreateCameraComponent implements OnInit {
  formularioCreateCamera: FormGroup;
  listLoca: Location[];
  listSubLoca: SubLocation[];
  saveShow: boolean = true;
   
  constructor(private fb: FormBuilder, public dialog: MatDialog, private cameraService: CameraService,
    private locaService: LocationService, private route: Router) { }

  ngOnInit(): void {
    this.InitFormulario();
    var idUser = sessionStorage.getItem("user");
    this.locaService.GetLocations(idUser).subscribe(x => this.ConfirmLoca(x), error => console.log(error));

  }
  ConfirmLoca(x: Location[]): void {
    if (x.length != 0) {
      this.listLoca = x;

      }
    }
  InitFormulario() {
    this.formularioCreateCamera = this.fb.group(
      {

        name: ["", Validators.required],
        location: ["", Validators.required],
        sublocation: ["", Validators.required],

      });
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

    let camare: Camera = new Camera();
    var idUser = sessionStorage.getItem("user");
    camare.id = Guid.create()["value"];
    camare.idLocation = this.formularioCreateCamera.controls["location"].value;
    camare.idSubLocation = this.formularioCreateCamera.controls["sublocation"].value;
    camare.idUser = Guid.parse(idUser)["value"];
    
    camare.name = this.formularioCreateCamera.controls["name"].value;
    console.log(camare)
    this.cameraService.Create(camare).subscribe(x => this.ConfirmCamare(x), error => console.log(error));

  }
  ConfirmCamare(x: any): void {
    if (x.statusCode == 200) {
      this.route.navigate(["Home/Cameras"])
      return;
    }
    this.saveShow = true;
  }
  NewLocation() {
    const dia = this.dialog.open(CreateLocationComponent, {
      data: {
        tit: "Create Location",
        name: "Name location",
        place: "Name of location",
        key: "location"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {

        this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.ConfirmLoca(x), error => console.log(error))

      }
    });
  }

  NewSubLocation() {
    const dia = this.dialog.open(CreateLocationComponent, {
      data: {
        tit: "Create Sub Location",
        name: "Name Sub Location",
        place: "Name of Sub Location",
        key: "sublocation",
        idLoca: this.formularioCreateCamera.controls["location"].value
      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listSubLoca = null;
        this.locaService.GetSubLocations(this.formularioCreateCamera.controls["location"].value).subscribe(x => this.ConfirmSubLocations(x), error => console.log(error))

      }
    });
  }
}

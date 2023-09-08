import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';

import { Camera } from '../../Models/camera';
import { CameraService } from '../../Services/camera.service';
import { DeleteComponent } from '../modals/delete/delete.component';
import { UpdateCameraComponent } from '../modals/update-camera/update-camera.component';

@Component({
  selector: 'app-cameras-settings',
  templateUrl: './cameras-settings.component.html',
  styleUrls: ['./cameras-settings.component.css']
})
export class CamerasSettingsComponent implements OnInit {
  listCamaeras: Camera[];
  constructor(public dialog: MatDialog,private route: Router, private cameraService: CameraService) { }

  ngOnInit(): void {
   
    this.cameraService.Get(Guid.parse(sessionStorage.getItem("user"))["value"]).subscribe(x => this.ConfirmCameras(x), error => console.log(error));
  }
  ConfirmCameras(x: any): void {
    console.log(x);
    this.listCamaeras = x;
    }
  CreateCameras() {
    this.route.navigate(["Home/CreateCamera"])
  }
  Delete(li:Camera) {
    const dia = this.dialog.open(DeleteComponent, {
      data: {
        tit: "Delete Camera",
        msg: "The " + li.name + " camera will be removed",
        loca: li,
        key: "camera"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listCamaeras = null;
        this.cameraService.Get(Guid.parse(sessionStorage.getItem("user"))["value"]).subscribe(x => this.ConfirmCameras(x), error => console.log(error))

      }
    });
  }

  Update(li:Camera) {
    const dia = this.dialog.open(UpdateCameraComponent, {
      data: {
       
          cam:li
      },
      height: "52%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listCamaeras = null;
        this.cameraService.Get(Guid.parse(sessionStorage.getItem("user"))["value"]).subscribe(x => this.ConfirmCameras(x), error => console.log(error))

      }
    });
  }
   
}

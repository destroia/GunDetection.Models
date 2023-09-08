import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Camera } from '../../Models/camera';
import { Location } from '../../Models/location';
import { CameraService } from '../../Services/camera.service';
import { LocationService } from '../../Services/location.service';

@Component({
  selector: 'app-security-wall',
  templateUrl: './security-wall.component.html',
  styleUrls: ['./security-wall.component.css']
})
export class SecurityWallComponent implements OnInit {
  col: string = "col-12"
  colBar: string = "col-0"
  colCam: string = "col-xl-3 col-lg-4 col-sm-6";
  listCam: Camera[];
  listLoca: Location[];
  bar: boolean = false;
  constructor(private locaService: LocationService, private camService: CameraService) { }

  ngOnInit(): void {
    this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.ConfirmarLoca(x), error => console.log(error));
    this.camService.Get(Guid.parse(sessionStorage.getItem("user"))["value"]).subscribe(x => this.ConfirmarCamera(x), error => console.log(error));
  }

  ConfirmarLoca(x: any): void {
    this.listLoca = x;
  }
  ConfirmarCamera(x: any): void {
    this.listCam = x;
  }
  ActionRequired() {
    this.col = "col-8";
    this.colBar = "col-2";
    this.bar = true;
    this.colCam = "col-xl-4 col-lg-6 col-sm-6";
  }
  AlertDetails() {

  }
  Confirmar() {

  }
  False() { }
  Closed() {
    this.col = "col-12"
    this.colBar = "col-0"
    this.colCam = "col-xl-3 col-lg-4 col-sm-6";
    this.bar = false;
  }
  View() {
    if (this.col == "col-4") {
      this.col = "col-8";
      this.colBar = "col-2";
      this.colCam = "col-xl-4 col-lg-6 col-sm-6";
    }
    else {
      this.col = "col-4"
      this.colBar = "col-6"
      this.colCam = "col-xl-6 col-lg-6 col-sm-6";
    }
   
  }

}

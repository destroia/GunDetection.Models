import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { cwd } from 'process';
import { Alert } from '../../Models/alert';
import { Camera } from '../../Models/camera';
import { FiltroAlert } from '../../Models/filtro-alert';
import { Location } from '../../Models/location';
import { AlertService } from '../../Services/alert.service';
import { CameraService } from '../../Services/camera.service';
import { LocationService } from '../../Services/location.service';

@Component({
  selector: 'app-alerts',
  templateUrl: './alerts.component.html',
  styleUrls: ['./alerts.component.css']
})
export class AlertsComponent implements OnInit {

  constructor(private route: Router, private alertService: AlertService, private locaService: LocationService,private camService : CameraService) { }
  listLoca: Location[];
  listAlerts: Alert[];
  listCam: Camera[];

  typeAlert: string = "";
  Status: string = "";
  TotalPaginas: number = 0;

  from: string = Date.now().toLocaleString().toString();
  to: string = "";
  filtro: FiltroAlert = new FiltroAlert();

  ngOnInit(): void {
    //this.filtro.idAccount = sessionStorage.getItem("user");
    this.from = "2021-01-01T00:00:00";
    this.to = "2100-01-01T00:00:00";

    this.filtro.from = this.from;
    this.filtro.to = this.to;
    this.filtro.typeAlert = this.typeAlert;
    this.filtro.status = this.Status;
    this.filtro.pag = 1;

    this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));
    this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.ConfirmarLoca(x), error => console.log(error));
    this.camService.Get(Guid.parse(sessionStorage.getItem("user"))["value"]).subscribe(x => this.ConfirmarCamera(x), error => console.log(error));
  }
    ConfirmarCamera(x: any): void {
      this.listCam = x;
    }
    ConfirmarLoca(x: any): void {
      this.listLoca = x;
    }
  ConfirmarAlert(x: any): void {
    this.listAlerts = x.res;
    this.TotalPaginas = x.totalPaginas;
    console.log(x)
    }

  AlertDetails(li: Alert) {
    sessionStorage.setItem("alert", JSON.stringify(li));
    this.route.navigate(["Home/Alert/Details"]);
    console.log("asdasdasd")
  }
  Confirmar(li: Alert) {
    li.status = "true";
    li.idAccount = sessionStorage.getItem("user");
    li.idUser = sessionStorage.getItem("id");

    this.alertService.UpdateAlert(li).subscribe(x => this.ConfirUpdateAlert(x), error => console.log(error));
  }
    ConfirUpdateAlert(x: any): void {
     
      if (x.statusCode == 200) {
        this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));
      }
      
    }
  False(li : Alert) {
    li.status = "false";
    li.idAccount = sessionStorage.getItem("user");
    li.idUser = sessionStorage.getItem("id");

    this.alertService.UpdateAlert(li).subscribe(x => this.ConfirUpdateAlert(x), error => console.log(error));
  }
  ChangedFilter() {
    this.filtro.from = this.from + "T00:00:00";
    this.filtro.to = this.to + "T00:00:00";
    this.filtro.typeAlert = this.typeAlert;
    this.filtro.status = this.Status;
    this.filtro.from = this.from;
    this.filtro.to = this.to;
    this.filtro.typeAlert = this.typeAlert;
    this.filtro.status = this.Status;


    this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));

  }
  Ant() {
    if (this.filtro.pag > 1) {
      this.filtro.pag -= 1;
      this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));
    }
  }
  Sig() {
    if (this.TotalPaginas > 1 && this.TotalPaginas > this.filtro.pag) {
      this.filtro.pag += 1;
      console.log(this.filtro)
      this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));

    }
  }
  Ult() {
    if (this.TotalPaginas != this.filtro.pag) {
      this.filtro.pag = this.TotalPaginas;
      console.log(this.filtro)
      this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));

    }
  }
  Pri() {
    if (this.filtro.pag != 1) {
      this.filtro.pag = 1;
      console.log(this.filtro)
      this.alertService.GetListAlerts(this.filtro).subscribe(x => this.ConfirmarAlert(x), error => console.log(error));

    }
  }
}

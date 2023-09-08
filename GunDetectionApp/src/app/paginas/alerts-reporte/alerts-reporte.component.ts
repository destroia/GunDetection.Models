import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Alert } from '../../Models/alert';
import { AlertService } from '../../Services/alert.service';
import { MapModalComponent } from '../Modals/map-modal/map-modal.component';

@Component({
  selector: 'app-alerts-reporte',
  templateUrl: './alerts-reporte.component.html',
  styleUrls: ['./alerts-reporte.component.css']
})
export class AlertsReporteComponent implements OnInit {

  constructor(public dialog: MatDialog, private router: Router, 
    private alertService: AlertService) { }
  base64data1: any;
  alert: Alert;
  showConfir: boolean = true;
  ngOnInit(): void {

    this.alert = JSON.parse(sessionStorage.getItem("alertRepo"));
    if (this.alert == null) {
      this.router.navigate(["Home/Reports"]);
    }
    sessionStorage.removeItem("alertRepo");

    if (this.alert.status != "") {
      this.showConfir = false
    }

  }

  Imagen() {

    alert("Todo");
  }
  Map() {
    const dia = this.dialog.open(MapModalComponent, {
      data: {
        lat: 51.673858,
        lon: 7.815982
      },
      height: "80%",//450px',
      width: '90%'
    });




  }
  base64ImageString;
  Download() {
    window.open(this.alert.full_photo, '_blank');
  }
  Admin() {
    alert("Todo");
  }
  Confirm() {
    this.alert.status = "true";
    this.alert.idAccount = sessionStorage.getItem("user");
    this.alert.idUser = sessionStorage.getItem("id");

    this.alertService.UpdateAlert(this.alert).subscribe(x => this.ConfirUpdateAlert(x), error => console.log(error));


  }
  ConfirUpdateAlert(x: any): void {
    if (x.statusCode == 200) {
      this.router.navigate(["Home"]);
    }
  }
  False() {
    this.alert.status = "false";
    this.alert.idAccount = sessionStorage.getItem("user");
    this.alert.idUser = sessionStorage.getItem("id");

    this.alertService.UpdateAlert(this.alert).subscribe(x => this.ConfirUpdateAlert(x), error => console.log(error));


  }



}

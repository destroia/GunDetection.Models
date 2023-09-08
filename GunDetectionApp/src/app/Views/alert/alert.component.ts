import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Alert } from '../../Models/alert';
import { MapModalComponent } from '../../paginas/Modals/map-modal/map-modal.component';
import { AlertService } from '../../Services/alert.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit {

  constructor(public dialog: MatDialog, private activateRoute: ActivatedRoute, private alertService: AlertService) { }
  alert: Alert;
  idU: string;
  ngOnInit(): void {

    this.activateRoute.queryParams.subscribe(param =>
      this.idU = param['Id']);
    console.log(this.idU)
    if (this.idU != null) {
      this.alertService.GetByIdAlert(this.idU).subscribe(x => this.ConfirmGet(x), error => console.log(error));
    }
  }
    ConfirmGet(x: Alert): void {
      this.alert = x;
      console.log(x)
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
    alert("Todo");
  }
  False() {
    alert("Todo");
  }


  

}

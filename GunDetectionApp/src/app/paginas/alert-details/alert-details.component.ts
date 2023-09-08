import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Alert } from '../../Models/alert';
import { AlertService } from '../../Services/alert.service';
import { GetImageService } from '../../Services/get-image.service';
import { MapModalComponent } from '../Modals/map-modal/map-modal.component';

@Component({
  selector: 'app-alert-details',
  templateUrl: './alert-details.component.html',
  styleUrls: ['./alert-details.component.css']
})
export class AlertDetailsComponent implements OnInit {

  constructor(public dialog: MatDialog, private router: Router, private getImgService: GetImageService,
    private alertService: AlertService) { }
  base64data1: any;
  alert: Alert;
  ngOnInit(): void {

    this.alert = JSON.parse(sessionStorage.getItem("alert"));
    if (this.alert == null) {
      this.router.navigate(["Home"]);
    }
    sessionStorage.removeItem("alert");
    
    //fetch('https://upload.wikimedia.org/wikipedia/commons/7/77/Delete_key1.jpg')
    //  .then(res => res.blob()) // Gets the response and returns it as a blob
    //  .then(blob => {
    //    // Here's where you get access to the blob
    //    // And you can use it for whatever you want
    //    // Like calling ref().put(blob)

    //    // Here, I use it to make an image appear on the page
    //    let objectURL = URL.createObjectURL(blob);
    //    console.log(blob);
    //    console.log(objectURL)
    //    let myImage = new Image();
    //    myImage.src = objectURL;

    //    this.downloadBlob("Picture", blob);
        
       
    //  });

   
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
  

  //downloadBlob(fileName: string, blob: Blob): void {
  //  if (window.navigator.msSaveOrOpenBlob) {
  //    window.navigator.msSaveBlob(blob, fileName);
  //  } else {
  //    const anchor = window.document.createElement('a');
  //    anchor.href = window.URL.createObjectURL(blob);
  //    anchor.download = fileName;
  //    document.body.appendChild(anchor);
  //    anchor.click();
  //    document.body.removeChild(anchor);
  //    window.URL.revokeObjectURL(anchor.href);
  //  }
  //}

 
}

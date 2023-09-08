import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-map-modal',
  templateUrl: './map-modal.component.html',
  styleUrls: ['./map-modal.component.css']
})
export class MapModalComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<MapModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,) { }
  lat: number = this.data.lat
  log: number = this.data.lon;
  zoom = 18;
  ngOnInit(): void {
  }

  OnClick() {
    this.dialogRef.close(false);
  }
}

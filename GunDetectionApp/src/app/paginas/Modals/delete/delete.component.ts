import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CameraService } from '../../../Services/camera.service';
import { LocationService } from '../../../Services/location.service';
import { SubUsersService } from '../../../Services/sub-users.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  error: boolean = false;
  constructor(public dialogRef: MatDialogRef<DeleteComponent>, private locaService: LocationService,
    @Inject(MAT_DIALOG_DATA) public data: any, private cameraService: CameraService, private SubUserService: SubUsersService) { }

  ngOnInit(): void {

  }

  OnClick() {
    this.dialogRef.close(false);
  }
  Delete() {
    if (this.data.key == "location") {
      this.locaService.DeleteLocation(this.data.loca).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "sublocation") {
      this.locaService.DeleteSubLocation(this.data.loca).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "camera") {
      this.cameraService.Delete(this.data.loca).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "UserAccessApp") {
      this.SubUserService.DeleteAccess(this.data.loca).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    if (this.data.key == "UserAlarm") {
     
      this.SubUserService.DeleteAlarm(this.data.loca).subscribe(x => this.Confirm(x), error => console.log(error));
    }
    
  }
  Confirm(x: any): void {

    if (x.statusCode == 200) {
      
        this.dialogRef.close(true);
      }
      else {
        this.error = true;
      }
    }
}

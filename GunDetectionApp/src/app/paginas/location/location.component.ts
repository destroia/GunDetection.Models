import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Location } from '../../Models/location';
import { LocationService } from '../../Services/location.service';
import { CreateLocationComponent } from '../modals/create-location/create-location.component';
import { DeleteComponent } from '../modals/delete/delete.component';
import { UpdateComponent } from '../modals/update/update.component';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {

  constructor(public dialog: MatDialog, private locaService: LocationService,private route: Router) { }
  listLoca: Location[];
  ngOnInit(): void {
    this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.Confirm(x), error => console.log(error))
  }
  CreateLocation() {
    const dia = this.dialog.open(CreateLocationComponent, {
      data: {
        tit: "Create Location",
        name: "Name location",
        place: "Name of location",
        key:"location"

      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {

        this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.Confirm(x),error => console.log(error))

      }
    });
  }
  Confirm(x: any): void {
    this.listLoca = x;
  }
  Delete(li: Location) {
    
    const dia = this.dialog.open(DeleteComponent, {
      data: {
        tit: "Delete Location" ,
        msg: "The " + li.name + " location will be removed",
        loca: li,
        key:"location"
        
      },
      height: "55%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listLoca = null;
        this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Show(li) {
    sessionStorage.setItem("lo",JSON.stringify(li) );
    this.route.navigate(["Home/SubLocations"]);
  }
  Update(li) {
    const dia = this.dialog.open(UpdateComponent, {
      data: {
        tit: "Update Location",
        name: "Name Location",
        plase: "Name of Location",
        loca: li,
        key: "location"

      },
      height: "42%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listLoca = null;
        this.locaService.GetLocations(sessionStorage.getItem("user")).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
}

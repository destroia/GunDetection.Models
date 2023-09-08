import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Location, SubLocation } from '../../Models/location';
import { LocationService } from '../../Services/location.service';
import { CreateLocationComponent } from '../modals/create-location/create-location.component';
import { DeleteComponent } from '../modals/delete/delete.component';
import { UpdateComponent } from '../modals/update/update.component';

@Component({
  selector: 'app-sub-location',
  templateUrl: './sub-location.component.html',
  styleUrls: ['./sub-location.component.css']
})
export class SubLocationComponent implements OnInit {
  loca: Location;
  listSubLoca: SubLocation[];

  constructor(public dialog: MatDialog, private locaService: LocationService, private route: Router) { }

  ngOnInit(): void {
    this.loca = JSON.parse(sessionStorage.getItem("lo"));
    
    this.locaService.GetSubLocations(this.loca.id.toString()).subscribe(x => this.Confirm(x), error => console.log(error));
  }
  Confirm(x: any): void {
    this.listSubLoca = x;
    }
  CreateSubLocation() {
    const dia = this.dialog.open(CreateLocationComponent, {
      data: {
        tit: "Create Sub Location",
        name: "Name Sub Location",
        place: "Name of Sub Location",
        key: "sublocation",
        idLoca: this.loca.id
      },
      height: "50%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listSubLoca = null;
        this.locaService.GetSubLocations(this.loca.id.toString()).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Delete(li: SubLocation) {

    const dia = this.dialog.open(DeleteComponent, {
      data: {
        tit: "Delete Sub Location",
        msg: "The " + li.name + " Sub location will be removed",
        loca: li,
        key: "sublocation"

      },
      height: "55%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listSubLoca = null;
        this.locaService.GetSubLocations(this.loca.id.toString()).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }

  Update(li) {
    const dia = this.dialog.open(UpdateComponent, {
      data: {
        tit: "Update Sub Location",
        name: "Name Sub Location",
        plase: "Name of Sub Location",
        subloca: li,
        key: "sublocation"

      },
      height: "42%",
      width: '90%'
    });

    dia.afterClosed().subscribe(res => {
      if (res) {
        this.listSubLoca = null;
        this.locaService.GetSubLocations(this.loca.id.toString()).subscribe(x => this.Confirm(x), error => console.log(error))

      }
    });
  }
  Back() {
    this.route.navigate(["Home/Locations"])
  }
}

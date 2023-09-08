import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlertDetailsComponent } from './alert-details/alert-details.component';
import { AlertsReporteComponent } from './alerts-reporte/alerts-reporte.component';
import { AlertsComponent } from './alerts/alerts.component';
import { CamerasSettingsComponent } from './cameras-settings/cameras-settings.component';
import { CreateCameraComponent } from './create-camera/create-camera.component';
import { LocationComponent } from './location/location.component';
import { PaginasComponent } from './paginas.component';
import { ReportsComponent } from './reports/reports.component';
import { SecurityWallComponent } from './security-wall/security-wall.component';
import { SubLocationComponent } from './sub-location/sub-location.component';
import { UserAccessComponent } from './user-access/user-access.component';
import { UserAlarmComponent } from './user-alarm/user-alarm.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: 'Home', component: PaginasComponent ,
    children: [
      { path: '', component: AlertsComponent },
      { path: 'Alerts', component: AlertsComponent, },
      { path: 'Alert/Details', component: AlertDetailsComponent },
      { path: 'SecurityWall', component: SecurityWallComponent },
      { path: 'Locations', component: LocationComponent },
      { path: 'SubLocations', component: SubLocationComponent },
      { path: 'Cameras', component: CamerasSettingsComponent },
      { path: 'CreateCamera', component: CreateCameraComponent },
      { path: 'User', component: UserComponent },
      { path: 'UserAccessApp', component: UserAccessComponent },
      { path: 'UserAlarm', component: UserAlarmComponent },
      { path: "Reports", component: ReportsComponent },
      { path: "ReportsAlert", component: AlertsReporteComponent }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaginasRoutingModule { }

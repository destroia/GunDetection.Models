import { NgModule } from '@angular/core';
import { CommonModule, HashLocationStrategy, LocationStrategy } from '@angular/common';

import { PaginasRoutingModule } from './paginas-routing.module';
import { PaginasComponent } from './paginas.component';
import { NavBarListComponent } from '../Views/nav-bar-list/nav-bar-list.component';
import { AlertsComponent } from './alerts/alerts.component';


//Material
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { A11yModule } from '@angular/cdk/a11y';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { OverlayModule } from '@angular/cdk/overlay';
import { AlertDetailsComponent } from './alert-details/alert-details.component';

import { environment } from '../../environments/environment';

import { AgmCoreModule, AgmMarker } from '@agm/core';
import { MapModalComponent } from './Modals/map-modal/map-modal.component';
import { HttpClientModule } from '@angular/common/http';
import { SecurityWallComponent } from './security-wall/security-wall.component';
import { LocationComponent } from './location/location.component';
import { CreateLocationComponent } from './modals/create-location/create-location.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteComponent } from './modals/delete/delete.component';
import { UpdateComponent } from './modals/update/update.component';
import { SubLocationComponent } from './sub-location/sub-location.component';
import { CamerasSettingsComponent } from './cameras-settings/cameras-settings.component';
import { CreateCameraComponent } from './create-camera/create-camera.component';
import { UpdateCameraComponent } from './modals/update-camera/update-camera.component';
import { UserComponent } from './user/user.component';
import { UserAccessComponent } from './user-access/user-access.component';
import { UserAlarmComponent } from './user-alarm/user-alarm.component';
import { UserAccessModalComponent } from './modals/user-access-modal/user-access-modal.component';
import { ReportsComponent } from './reports/reports.component';
import { AlertsReporteComponent } from './alerts-reporte/alerts-reporte.component';

@NgModule({
  declarations: [PaginasComponent,
    NavBarListComponent,
    AlertsComponent,
    AlertDetailsComponent,
    MapModalComponent,
    SecurityWallComponent,
    LocationComponent,
    CreateLocationComponent,
    DeleteComponent,
    UpdateComponent,
    SubLocationComponent,
    CamerasSettingsComponent,
    CreateCameraComponent,
    UpdateCameraComponent,
    UserComponent,
    UserAccessComponent,
    UserAlarmComponent,
    UserAccessModalComponent,
    ReportsComponent,
    AlertsReporteComponent],
  imports: [
    CommonModule,
    PaginasRoutingModule,
    //Maps

    AgmCoreModule.forRoot({
      // please get your own API key here:
      // https://developers.google.com/maps/documentation/javascript/get-api-key?hl=en
      apiKey: environment.apiKeyGoogle
    }),

    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    
    //Material
    A11yModule,
    ClipboardModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    OverlayModule,
    PortalModule,
    ScrollingModule,
    HttpClientModule,
  ],
  entryComponents: [MapModalComponent],

  providers: [ { provide: LocationStrategy, useClass: HashLocationStrategy }],
})
export class PaginasModule { }

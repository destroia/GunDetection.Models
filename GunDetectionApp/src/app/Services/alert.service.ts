import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Alert } from '../Models/alert';
import { FiltroAlert } from '../Models/filtro-alert';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private http: HttpClient) { }

  GetAlert(): Observable<Alert[]> {
    return this.http.get<Alert[]>(UrlService.UrlApi + "Alerts/Get");
  }
  GetByIdAlert(id :string): Observable<Alert> {
    return this.http.get<Alert>(UrlService.UrlApi + "Alerts/GetById/" + id);
  }
  UpdateAlert(alert: Alert): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Alerts/Update/" , alert);
  }
  GetReportsAlerts(filtro: FiltroAlert): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Alerts/GetReports/", filtro);
  }
  GetListAlerts(filtro: FiltroAlert): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Alerts/GetListAlerts/", filtro);
  }
}

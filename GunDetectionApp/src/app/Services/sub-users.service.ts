import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { User } from '../Models/user';
import { UserAlarm } from '../Models/user-alarm';
import { UrlService } from './url.service';


@Injectable({
  providedIn: 'root'
})
export class SubUsersService {

  constructor(private http: HttpClient) { }

  GetUsersAccess(id: Guid): Observable<any> {
    return this.http.get<any>(UrlService.UrlApi + "SubUsers/GetUsersAccess/"+ id)
  }

  GetUsersAlarm(id: Guid): Observable<any> {
    return this.http.get<any>(UrlService.UrlApi + "SubUsers/GetUsersAlarm/" +id)
  }

  CreateAccess(user: User): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/CreateUsersAccess", user);
  }
  CreateAlarm(user: UserAlarm): Observable<any> {

    if (user.gunDetected == null) {
      user.gunDetected = false;
    }
    if (user.figth == null) {
      user.figth = false;
    }
    if (user.handsUp == null) {
      user.handsUp = false;
    }
    if (user.personDetection == null) {
      user.personDetection = false;
    }
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/CreateUsersAlarm", user);
  }
  UpdateAccess(user: User): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/UpdateUsersAccess", user);
  }
  UpdateAlarm(user: UserAlarm): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/UpdateUsersAlarm", user);
  }
  DeleteAccess(user: User): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/DeleteUsersAccess", user);
  }
  DeleteAlarm(user: UserAlarm): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "SubUsers/DeleteUsersAlarm", user);
  }
}

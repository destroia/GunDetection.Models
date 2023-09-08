import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { Camera } from '../Models/camera';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class CameraService {

  constructor(private http: HttpClient) { }
  Get(iduser: Guid): Observable<any> {
    return this.http.get<any>(UrlService.UrlApi + "Cameras/Get/" + iduser);
  }
  Create(camera: Camera): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Cameras/Create/", camera);
  }
  Update(camera: Camera): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Cameras/Update/", camera);
  }
  Delete(camera: Camera): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Cameras/Delete/", camera);
  }
}

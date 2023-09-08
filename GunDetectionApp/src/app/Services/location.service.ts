import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Location, SubLocation } from '../Models/location';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }

  CreateLocation(Location: Location): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/CreateLocation", Location)
  }
  CreateSubLocation(Sub: SubLocation): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/CreateSubLocation", Sub)
  }

  GetLocations(id: string): Observable<any> {
    return  this.http.get<any>(UrlService.UrlApi + "Locations/Get/" + id);
  }
  GetSubLocations(id: string): Observable<any> {
    return this.http.get<any>(UrlService.UrlApi + "Locations/GetSub/" + id);
  }
  DeleteLocation(lo: Location): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/DeleteLocation/", lo);
  }
  DeleteSubLocation(lo: SubLocation): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/DeleteSubLocation/", lo);
  }
  UpdateLocation(lo: Location): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/UpdateLocation/", lo);
  }
  UpdateSubLocation(lo: SubLocation): Observable<any> {
    return this.http.post<any>(UrlService.UrlApi + "Locations/UpdateSubLocation/", lo);
  }

}

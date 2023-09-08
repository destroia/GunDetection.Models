import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor() { }

  public static UrlApi: string = "https://gundetectionapi20210512115045.azurewebsites.net/api/";//  "https://localhost:44331/api/";//
}

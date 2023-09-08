import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { CreatePassword } from '../Models/create-password';
import { Login } from '../Models/login';
import { User } from '../Models/user';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  Login(l: Login): Observable<any> {

    return this.http.post<any>(UrlService.UrlApi + "Users/Login", l);
  }
  SignIn(u: User): Observable<any> {

    return this.http.post<any>(UrlService.UrlApi + "Users/SignIn", u);
  }
  CreatePassword(createP: CreatePassword): Observable<any> {

    return this.http.post<any>(UrlService.UrlApi + "Users/CreatePassword", createP);
  }
  LostPasword(mail: string): Observable<any> {

    return this.http.get<any>(UrlService.UrlApi + "Users/LostPasword/" + mail);
  }
  Validate(id: string): Observable<any> {

    return this.http.get<any>(UrlService.UrlApi + "Users/Validar/" + id);
  }
  GetById(id: Guid): Observable<User> {

    return this.http.get<User>(UrlService.UrlApi + "Users/GetById/" + id);
  }

}

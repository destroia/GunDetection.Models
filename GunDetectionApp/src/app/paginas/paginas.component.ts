import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-paginas',
  templateUrl: './paginas.component.html',
  styleUrls: ['./paginas.component.css']
})
export class PaginasComponent implements OnInit {

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private router: Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  

  ngOnInit(): void {

    let s = localStorage.getItem("user");
    let ss = sessionStorage.getItem("user");

    if (ss == null && s == null) {
      localStorage.removeItem("user");
      sessionStorage.removeItem("user");
      //this.router.navigate(["Login"]);
      return;
    }

    if (ss != null && s == null) {
      return;
    }
    if (s != null) {
      sessionStorage.setItem("user", s);
      
    }

    let sid = localStorage.getItem("id");
    let ssid = sessionStorage.getItem("id");

    if (ssid == null && sid == null) {
      localStorage.removeItem("user");
      sessionStorage.removeItem("user");
     //this.router.navigate(["Login"]);
      return;
    }

    if (ssid != null && sid == null) {
      return;
    }
    if (sid != null) {
      sessionStorage.setItem("id", sid);

    }
  }
  mobileQuery: MediaQueryList;


  private _mobileQueryListener: () => void;



  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  shouldRun = true;//[/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));

  Alert() {
    console.log("sss")
    
  }
  
  Logout() {
    localStorage.removeItem("user");
    sessionStorage.removeItem("user");
    this.router.navigate(["Login"]);
  }
}

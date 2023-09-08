import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar-list',
  templateUrl: './nav-bar-list.component.html',
  styleUrls: ['./nav-bar-list.component.css']
})
export class NavBarListComponent implements OnDestroy {

  mobileQuery: MediaQueryList;


  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private route: Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.getScreenHeight();
  }
  private _mobileQueryListener: () => void;



  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  Alert() {
    this.route.navigate(["Home/Alerts"])
  }
  SecurityWall() {
    this.route.navigate(["Home/SecurityWall"])
  }
  Locations() {
    this.route.navigate(["Home/Locations"])
  }
  Logout() {
    localStorage.removeItem("user");
    sessionStorage.removeItem("user");
    this.route.navigate(["Login"]);
  }

  events: string[] = [];
  opened: boolean;
  appropriateClass: string = '';

  @HostListener('window:resize', ['$event'])
  getScreenHeight(event?) {
    //console.log(window.innerHeight);
    if (window.innerHeight <= 412) {
      this.appropriateClass = 'bottomRelative';
    } else {
      this.appropriateClass = 'bottomStick';
    }
  }
}

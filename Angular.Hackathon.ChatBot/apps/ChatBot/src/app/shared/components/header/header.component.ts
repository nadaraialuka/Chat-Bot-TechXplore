import {ChangeDetectionStrategy, ChangeDetectorRef, Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent {
  userFullName: string;

  constructor(private _router: Router, private cdr: ChangeDetectorRef) {
    this.userFullName = 'ნადარაია ლუკა';
  }

  logout() {
    localStorage.clear();
    this._router.navigate(['logout']);
    this.cdr.detectChanges();
  }
}

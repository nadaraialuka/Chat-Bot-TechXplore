import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
})
export class HeaderComponent {
  userFullName: string;

  constructor(private _router: Router) {
    this.userFullName = 'ნადარაია ლუკა';
  }

  logout() {
    localStorage.clear();
    this._router.navigate(['logout'])
  }
}

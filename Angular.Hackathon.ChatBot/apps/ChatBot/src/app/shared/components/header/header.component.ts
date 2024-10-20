import {ChangeDetectionStrategy, ChangeDetectorRef, Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit, OnChanges {
  userFullName: string;
  customerId!: number

  constructor(private _router: Router, private cdr: ChangeDetectorRef) {
    this.userFullName = 'ნადარაია ლუკა';
  }

  ngOnInit() {
    this.customerId = JSON.parse(<string>localStorage.getItem('customerId'));
    this.cdr.detectChanges()
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.cdr.detectChanges()
  }

  logout() {
    localStorage.clear();
    this._router.navigate(['logout']);
  }
}

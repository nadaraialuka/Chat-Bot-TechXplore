import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  products: { name: string, route: string }[];

  constructor() {
    this.products = [
      {
        name: 'ანგარიშები',
        route: 'accounts'
      },
      {
        name: 'ბარათები',
        route: 'cards'
      },
      {
        name: 'დეპოზიტები',
        route: 'deposits'
      }
    ]
  }
}

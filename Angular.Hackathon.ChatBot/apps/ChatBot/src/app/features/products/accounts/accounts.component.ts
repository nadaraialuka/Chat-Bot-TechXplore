import {Component, Input} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Account} from "../../../services/products/products.service";

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.scss',
})
export class AccountsComponent {
  @Input() accounts!: Account[];

  constructor() {
  }
}

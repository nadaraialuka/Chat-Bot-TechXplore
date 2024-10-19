import {Component, Input} from '@angular/core';
import { CommonModule } from '@angular/common';
import {Deposit} from "../../../services/products/products.service";

@Component({
  selector: 'app-deposits',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './deposits.component.html',
  styleUrl: './deposits.component.scss',
})
export class DepositsComponent {
  @Input() deposits!: Deposit[];
}

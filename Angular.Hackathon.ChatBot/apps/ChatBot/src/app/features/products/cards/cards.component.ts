import {Component, Input, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Card} from "../../../services/products/products.service";

@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.scss',
})
export class CardsComponent {
  @Input() cards!: Card[];

  constructor() {

  }

}

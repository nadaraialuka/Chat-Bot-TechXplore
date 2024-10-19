import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ActivatedRoute, RouterLink, RouterOutlet} from "@angular/router";
import {Product, ProductsService} from "../../services/products/products.service";
import {AccountsComponent} from "./accounts/accounts.component";
import {DepositsComponent} from "./deposits/deposits.component";
import {CardsComponent} from "./cards/cards.component";

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, AccountsComponent, DepositsComponent, CardsComponent],
  providers: [ProductsService],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
})
export class ProductsComponent implements OnInit {
  productsMenu: { name: string, route: string }[];
  product!: Product;

  constructor(private route: ActivatedRoute) {
    this.productsMenu = [
      {
        name: 'ბარათები',
        route: 'cards'
      },
      {
        name: 'ანგარიშები',
        route: 'accounts'
      },
      {
        name: 'ანაბრები',
        route: 'deposits'
      }
    ]
  }

  ngOnInit() {
    this.route.data.subscribe(
      product => {
        this.product = product['products'];
      }
    );
  }

  //scroll to specific section
  scrollTo(section: string): void {
    const element = document.getElementById(section);
    if (element) {
      element.scrollIntoView({behavior: 'smooth', block: 'start'});
    }
  }
}

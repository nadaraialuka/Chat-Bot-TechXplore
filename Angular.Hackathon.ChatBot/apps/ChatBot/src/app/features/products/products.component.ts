import {ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ActivatedRoute, RouterLink, RouterOutlet} from "@angular/router";
import {Product, ProductsService} from "../../services/products/products.service";
import {AccountsComponent} from "./accounts/accounts.component";
import {DepositsComponent} from "./deposits/deposits.component";
import {CardsComponent} from "./cards/cards.component";
import {ChatbotComponent} from "../../shared/components/chatbot/chatbot.component";
import {HeaderComponent} from "../../shared/components/header/header.component";

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, AccountsComponent, DepositsComponent, CardsComponent, ChatbotComponent, HeaderComponent],
  providers: [ProductsService],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductsComponent implements OnInit {
  productsMenu: { name: string, route: string }[];
  product!: Product;
  activeTab: string = 'cards';

  constructor(private route: ActivatedRoute, private cdr: ChangeDetectorRef) {
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
    this.cdr.detectChanges()
  }

  //scroll to specific section
  scrollTo(section: string): void {
    this.activeTab = section

  }

  getNewProducts(event: any) {
    this.product = event;
    this.cdr.detectChanges();
  }
}

import {Route} from '@angular/router';
import {AccountsComponent} from "../features/products/accounts/accounts.component";
import {CardsComponent} from "../features/products/cards/cards.component";
import {DepositsComponent} from "../features/products/deposits/deposits.component";

export const appRoutes: Route[] = [
  {path: '', component: AccountsComponent},
  {path: 'accounts', component: AccountsComponent},
  {path: 'cards', component: CardsComponent},
  {path: 'deposits', component: DepositsComponent},
];

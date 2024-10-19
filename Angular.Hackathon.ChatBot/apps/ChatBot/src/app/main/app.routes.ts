import {Route} from '@angular/router';
import {productsResolver} from "../resolvers/products/products.resolver";
import {ProductsComponent} from "../features/products/products.component";

export const appRoutes: Route[] = [
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full',
  },
  {
    path: 'products',
    component: ProductsComponent,
    // children: [
    //   {
    //     path: 'accounts',
    //     loadComponent: () => import('../features/products/accounts/accounts.component').then((c) => c.AccountsComponent),
    //   },
    //   {
    //     path: 'cards',
    //     loadComponent: () => import('../features/products/cards/cards.component').then((c) => c.CardsComponent)
    //   },
    //   {
    //     path: 'deposits',
    //     loadComponent: () => import('../features/products/deposits/deposits.component').then((c) => c.DepositsComponent)
    //   },
    // ],
    resolve: {
      products: productsResolver
    },
  },

];

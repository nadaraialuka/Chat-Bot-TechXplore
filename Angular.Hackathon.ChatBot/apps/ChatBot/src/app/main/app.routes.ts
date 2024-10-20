import {Route} from '@angular/router';
import {productsResolver} from "../resolvers/products/products.resolver";
import {ProductsComponent} from "../features/products/products.component";
import {LoginComponent} from "../shared/components/login/login.component";

export const appRoutes: Route[] = [
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'products',
    component: ProductsComponent,
    resolve: {
      products: productsResolver
    },
  },
  {path: '**', redirectTo: 'login'}
];

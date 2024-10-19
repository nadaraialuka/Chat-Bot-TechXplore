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
    resolve: {
      products: productsResolver
    },
  },

];

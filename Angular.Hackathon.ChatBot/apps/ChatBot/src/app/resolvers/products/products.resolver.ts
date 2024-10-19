import {ResolveFn} from '@angular/router';
import {Product, ProductsService} from "../../services/products/products.service";
import {inject} from "@angular/core";

export const productsResolver: ResolveFn<Product> = (route, state) => {
  const customerId = 1;
  return inject(ProductsService).getProducts(customerId);
};

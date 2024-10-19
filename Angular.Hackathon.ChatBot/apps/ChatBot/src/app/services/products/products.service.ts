import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

export interface Product {
  accounts?: Account[],
  cards?: Card[],
  deposits?: Deposit[]
}

export interface Account {
  id: number;
  iban?: number;
  ccy?: string;
  type?: string;
  subtype?: string;
  customerId?: number;
  openDate?: Date | string;
}

export interface Card {
  id: number;
  name?: string;
  type?: string;
  iban?: string;
  ccys?: string[];
  customerId?: number;
}

export interface Deposit {
  id: number;
  name?: string;
  friendlyName?: string;
  customerId?: number;
  iban?: string;
  ccy?: string;
  openDate?: Date | string;
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private apiUrl = 'https://localhost:51532/'; //api endpoint
  constructor(private http: HttpClient) {
  }

  getProducts(customerId: number): Observable<Product> {
    // Define the headers with the customerId
    const headers = new HttpHeaders({
      'customerId': customerId
    });

    return this.http.get(`${this.apiUrl}ChatBot/products`, {headers});
  }
}

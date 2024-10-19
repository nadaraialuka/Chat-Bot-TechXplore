import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private apiUrl = 'https://localhost:51532/'; //api endpoint
  constructor(private http: HttpClient) {
  }

  chat(customerId: number, question: string): Observable<any> {
    // Define the headers with the customerId
    const headers = new HttpHeaders({
      'customerId': customerId
    });

    const params = new HttpParams().set('question', question);

    // Send POST request with headers and body
    return this.http.post(`${this.apiUrl}ChatBot/chat`, {}, {headers, params});
  }
}

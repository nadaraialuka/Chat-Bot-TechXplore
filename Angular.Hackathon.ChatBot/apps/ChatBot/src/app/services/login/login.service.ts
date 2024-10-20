import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = 'https://localhost:51532/'; //api endpoint
  constructor(private http: HttpClient) {
  }

  login(userName: string, password: string): Observable<any> {


    // Send POST request with headers and body
    return this.http.post(`${this.apiUrl}api/user/login`, {
      userName: userName,
      password: password
    });
  }
}

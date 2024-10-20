import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Router} from "@angular/router";
import {LoginService} from "../../../services/login/login.service";
import {catchError} from "rxjs";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  errorMessage = ''

  constructor(private _router: Router, private _loginService: LoginService) {
  }

  login() {
    this._loginService.login('nadaraialuka', 'luka1234').subscribe(res => {
        this._router.navigate(['products']);
        localStorage.setItem('customerId', JSON.stringify(res.customerId));
        console.log(res)
      },
      catchError((err) => {
        localStorage.clear();
        this.errorMessage = 'არასწორია მომხმარებლის სახელი ან პაროლი'
        console.log(err)
        return err
      })
    )
  }
}

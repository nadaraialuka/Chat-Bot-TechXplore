import {ChangeDetectionStrategy, ChangeDetectorRef, Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {Router} from "@angular/router";
import {LoginService} from "../../../services/login/login.service";
import {catchError} from "rxjs";
import {FormControl, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent {
  errorMessage = ''
  userName: FormControl = new FormControl('');
  password: FormControl = new FormControl('');

  constructor(private _router: Router, private _loginService: LoginService, private cdr: ChangeDetectorRef) {
  }


  login() {
    this._loginService.login(this.userName.value, this.password.value).subscribe(res => {
        this._router.navigate(['products']);
        localStorage.setItem('customerId', JSON.stringify(res.customerId));
        localStorage.setItem('authToken', JSON.stringify(res.authToken));
        localStorage.setItem('fullName', JSON.stringify(res.fullName));
      },
      catchError((err) => {
        localStorage.clear();
        this.errorMessage = 'არასწორია მომხმარებლის სახელი ან პაროლი'
        return err
      })
    )
    this.cdr.detectChanges();
  }
}

import {Component} from '@angular/core';
import {RouterModule} from '@angular/router';
import {LayoutComponent} from "../shared/components/layout/layout.component";
import {HttpClientModule} from "@angular/common/http";

@Component({
  standalone: true,
  imports: [RouterModule, LayoutComponent, HttpClientModule,],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'ChatBot';
}

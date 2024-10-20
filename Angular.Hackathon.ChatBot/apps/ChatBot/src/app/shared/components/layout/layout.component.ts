import {ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HeaderComponent} from "../header/header.component";
import {ChatbotComponent} from "../chatbot/chatbot.component";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, HeaderComponent, ChatbotComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LayoutComponent implements OnInit {
  customerId!: number;

  constructor(private cdr: ChangeDetectorRef) {
    this.customerId = JSON.parse(<string>localStorage.getItem('customerId'));
  }

  ngOnInit() {
    this.cdr.detectChanges()
  }

}

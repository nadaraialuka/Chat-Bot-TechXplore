import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormControl, ReactiveFormsModule} from "@angular/forms";
import {ChatService} from "../../../services/chat/chat.service";

@Component({
  selector: 'app-chatbot',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chatbot.component.html',
  styleUrl: './chatbot.component.scss',
})
export class ChatbotComponent {
  message: FormControl = new FormControl();

  constructor(private chatService: ChatService) {
  }

  sendMessage() {
    const customerId = 1
    this.chatService.chat(customerId, this.message.value).subscribe(r => alert(r.answer))
  }
}

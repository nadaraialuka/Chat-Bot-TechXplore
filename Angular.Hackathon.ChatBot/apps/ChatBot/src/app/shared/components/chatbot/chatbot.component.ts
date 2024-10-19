import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ProductsService} from "../../../services/products/products.service";
import {ChatService} from "../../../services/chat/chat.service";

@Component({
  selector: 'app-chatbot',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './chatbot.component.html',
  styleUrl: './chatbot.component.scss',
})
export class ChatbotComponent implements OnInit {
  isOpen = false;
  messages: any[] = [];
  newMessage = '';
  isLoading = false;

  constructor(private chatService: ChatService, private productsService: ProductsService) {
  }

  ngOnInit() {
    this.loadMessages();
  }

  toggleChat() {
    if (this.isOpen) {
      this.closeChat();
    } else {
      this.openChat();
    }
  }

  openChat() {
    this.isOpen = true;
    this.loadMessages();
  }

  closeChat() {
    this.isOpen = false;
    this.clearLocalStorage();
    this.messages = [];
  }

  clearLocalStorage() {
    localStorage.removeItem('chatMessages');
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.addMessage(this.newMessage, true);
      // Simulate a response (replace this with actual API call)
      // setTimeout(() => {
      //   this.addMessage('This is a simulated response.', false);
      // }, 1000);
      this.isLoading = true;
      const customerId = 1
      this.chatService.chat(customerId, this.newMessage).subscribe(r => {
        this.addMessage(r.answer, false);
        if (r.isFinalAnswer) {
          this.productsService.getProducts(customerId)
        }
        this.isLoading = false;
      });
      this.newMessage = '';
    }
  }

  addMessage(text: string, isUser: boolean) {
    this.messages.push({text, isUser});
    this.saveMessages();
  }

  saveMessages() {
    localStorage.setItem('chatMessages', JSON.stringify(this.messages));
  }

  loadMessages() {
    const savedMessages = localStorage.getItem('chatMessages');
    if (savedMessages) {
      this.messages = JSON.parse(savedMessages);
    }
  }

  /*
   message: FormControl = new FormControl();
   response!: string;

   constructor(private chatService: ChatService, private productsService: ProductsService) {
   }

   sendMessage() {
     const customerId = 1
     this.chatService.chat(customerId, this.message.value).subscribe(r => {
       this.response = r.answer;
       if (r.isFinalAnswer) {
         this.productsService.getProducts(customerId)
       }

     });
   }

   */
}

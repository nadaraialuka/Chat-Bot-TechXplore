import {AfterViewChecked, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
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
export class ChatbotComponent implements OnInit, AfterViewChecked {
  private shouldScroll = false;

  isOpen = false;
  messages: any[] = [];
  newMessage = '';
  isLoading = false;
  showNotification = false;

  @ViewChild('chatContainer') private chatContainer!: ElementRef;


  constructor(private chatService: ChatService, private productsService: ProductsService) {
  }

  ngOnInit() {
    this.loadMessages();
  }

  ngAfterViewChecked() {
    if (this.shouldScroll) {
      this.scrollToBottom();
      this.shouldScroll = false;
    }
  }

  scrollToBottom() {
    try {
      this.chatContainer.nativeElement.scrollTop = this.chatContainer.nativeElement.scrollHeight;
    } catch (err) {
    }
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
    this.shouldScroll = true;
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
      this.isLoading = true;
      const customerId = 1
      this.chatService.chat(customerId, this.newMessage).subscribe(r => {
        this.addMessage(r.answer, false, r.isFinalAnswer);
        if (r.isFinalAnswer) {
          this.productsService.getProducts(customerId).subscribe()
        }
        this.isLoading = false;
      });
      this.newMessage = '';
    }
    this.shouldScroll = true;
  }

  addMessage(text: string, isUser: boolean, isFinalAnswer: boolean = false) {
    this.messages.push({text, isUser});
    this.saveMessages();
    this.shouldScroll = true;
    if (isFinalAnswer) {
      this.showSuccessNotification();
    }
  }

  showSuccessNotification() {
    this.showNotification = true;
    setTimeout(() => {
      this.showNotification = false;
    }, 3000); // Hide notification after 3 seconds
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
}

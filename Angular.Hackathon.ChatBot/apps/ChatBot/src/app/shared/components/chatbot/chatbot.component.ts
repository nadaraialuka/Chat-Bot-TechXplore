import {
  AfterViewChecked,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  ElementRef,
  EventEmitter,
  OnInit,
  Output,
  ViewChild
} from '@angular/core';
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
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChatbotComponent implements OnInit, AfterViewChecked {
  private shouldScroll = false;

  isOpen = false;
  messages: any[] = [];
  newMessage = '';
  isLoading = false;
  showNotification = false;

  @Output() productsData: EventEmitter<any> = new EventEmitter()
  @ViewChild('chatContainer') private chatContainer!: ElementRef;


  constructor(private chatService: ChatService, private productsService: ProductsService, private cdr: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.loadMessages();
    this.cdr.detectChanges();
  }

  ngAfterViewChecked() {
    if (this.shouldScroll) {
      this.scrollToBottom();
      this.shouldScroll = false;
    }
    this.cdr.detectChanges();
  }

  scrollToBottom() {
    try {
      this.chatContainer.nativeElement.scrollTop = this.chatContainer.nativeElement.scrollHeight;
    } catch (err) {
      console.error(err)
    }
    this.cdr.detectChanges();

  }

  toggleChat() {
    if (this.isOpen) {
      this.closeChat();
    } else {
      this.openChat();
    }
    this.cdr.detectChanges();
  }

  openChat() {
    this.isOpen = true;
    this.loadMessages();
    this.shouldScroll = true;
    this.cdr.detectChanges();
  }

  closeChat() {
    this.isOpen = false;
    this.clearLocalStorage();
    this.messages = [];
    this.cdr.detectChanges();
  }

  clearLocalStorage() {
    localStorage.removeItem('chatMessages');
    this.cdr.detectChanges();
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.addMessage(this.newMessage, true);
      this.isLoading = true;
      const customerId = JSON.parse(<string>localStorage.getItem('customerId'));
      this.chatService.chat(customerId, this.newMessage).subscribe(r => {
        this.addMessage(r.answer, false, r.isFinalAnswer);
        if (r.isFinalAnswer) {
          this.productsService.getProducts(customerId).subscribe(r => {
            this.productsData.emit(r)
          })
          this.cdr.detectChanges();
        }
        this.isLoading = false;
        this.cdr.detectChanges()
        
      });
      this.newMessage = '';
      this.cdr.detectChanges()
    }
    this.shouldScroll = true;
    this.cdr.detectChanges();
  }

  addMessage(text: string, isUser: boolean, isFinalAnswer: boolean = false) {
    this.messages.push({text, isUser});
    this.saveMessages();
    this.shouldScroll = true;
    if (isFinalAnswer) {
      this.showSuccessNotification();
    }
    this.cdr.detectChanges();

  }

  showSuccessNotification() {
    this.showNotification = true;
    setTimeout(() => {
      this.showNotification = false;
      this.cdr.detectChanges();
    }, 3000); // Hide notification after 3 seconds
    this.cdr.detectChanges();

  }

  saveMessages() {
    localStorage.setItem('chatMessages', JSON.stringify(this.messages));
    this.cdr.detectChanges();

  }

  loadMessages() {
    const savedMessages = localStorage.getItem('chatMessages');
    if (savedMessages) {
      this.messages = JSON.parse(savedMessages);
    }
    this.cdr.detectChanges();
  }
}

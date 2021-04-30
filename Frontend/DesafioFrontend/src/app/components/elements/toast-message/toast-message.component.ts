import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { DataTransferService } from 'src/app/core/data-transfer.service';

@Component({
  selector: 'app-toast-message',
  templateUrl: './toast-message.component.html',
  styleUrls: ['./toast-message.component.css'],
  animations: [
    trigger('slideInOut', [
      transition(':enter', [
        style({ bottom: '-100px' }),
        animate('0.5s ease-in-out')
      ]),
      transition(':leave', 
        animate('0.5s ease-in-out', style({ bottom: '-100px'})
      ))
    ])
  ]
})
export class ToastMessageComponent implements OnInit, OnDestroy {

  @Input() hasError = false;
  @Input() hasSuccess = false;
  @Input() message = '';
  private subscription: Subscription;
  
  constructor(private dataTransferService: DataTransferService) { }

  ngOnInit(): void {
    this.initDataTransfer();
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  private initDataTransfer() {
    this.subscription = this.dataTransferService.getToastMessage()
      .subscribe(data => {
        this.message = data.message;
        if (data.success) {
          this.hasSuccess = true;
        } else {
          this.hasError = true;
        }
        setTimeout(() => {
          this.clearMessage();
        }, 3000);
      });
  }

  private clearMessage() {
    this.hasError = false;
    this.hasSuccess = false;
    this.message = '';
  }

}

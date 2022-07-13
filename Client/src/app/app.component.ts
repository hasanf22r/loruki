import { Component } from '@angular/core';
import { OrderService } from './order/order.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Client';
  basketCount:number=0;
  constructor(private orderService: OrderService){
    orderService.basket.subscribe(next=>{
      this.basketCount = next.length
    })
  }
}

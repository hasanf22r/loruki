import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/Models/Product';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss'],
})
export class OrderListComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  basket: Product[] = [];
  ngOnInit(): void {
    this.orderService.basket.subscribe((next) => {
      this.basket = next;
    });
  }
}

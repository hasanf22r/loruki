import { Component, OnInit } from '@angular/core';
import { GeneralService } from 'src/app/services/general.service';
import { Product } from 'src/app/shared/Models/Product';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  constructor(private gService: GeneralService,private orderService: OrderService) {}

  product!: Product[];
  ngOnInit(): void {
    this.gService.httpGet<Product[]>('product/getall', {}).subscribe((res) => {
      this.product = res;
    });
  }

  addToBasket(p: Product)
  {
    this.orderService.addToBasket(p)
  }
}

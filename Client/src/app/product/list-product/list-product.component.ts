import { Component, OnInit } from '@angular/core';
import { GeneralService } from 'src/app/services/general.service';
import { Product } from 'src/app/shared/Models/Product';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss'],
})
export class ListProductComponent implements OnInit {
  constructor(private gService: GeneralService) {}

  product!: Product[];
  ngOnInit(): void {
    this.gService.httpGet<Product[]>('product/getall', {}).subscribe((res) => {
      this.product = res;
    });
  }
}

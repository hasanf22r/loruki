import { Injectable } from '@angular/core';
import { BehaviorSubject, take } from 'rxjs';
import { ProductModule } from '../product/product.module';
import { Product } from '../shared/Models/Product';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  public basket: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>(
    []
  );
  constructor() {}

  addToBasket(p: Product) {
    this.basket
      .asObservable()
      .pipe(take(1))
      .subscribe((next) => {
        this.basket.next([...next, p]);
      });
  }

  removeFromBasket(p: Product) {
    this.basket
      .asObservable()
      .pipe(take(1))
      .subscribe((next) => {
        this.basket.next([...next.filter((a) => a.id === p.id)]);
      });
  }
}

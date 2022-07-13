import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductModule } from './product/product.module';

const routes: Routes = [
  {
    path: 'product',
    loadChildren: () =>
      import('./product/product.module').then((t) => t.ProductModule),
  },
  {
    path: 'order',
    loadChildren: () =>
      import('./order/order.module').then((t) => t.OrderModule),
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./user/user.module').then((t) => t.UserModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

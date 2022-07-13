import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order/order.component';
import { Routes, RouterModule } from '@angular/router';
import { OrderListComponent } from './order-list/order-list.component';
const routes: Routes = [
  {
    path: '',
    component: OrderComponent,
  },
  {
    path: 'list',
    component: OrderListComponent,
  },
];

@NgModule({
  declarations: [
    OrderComponent,
    OrderListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class OrderModule { }

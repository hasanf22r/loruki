import { NgModule } from '@angular/core';
import { ListProductComponent } from './list-product/list-product.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
  {
    path: 'create',
    component: CreateProductComponent,
  },
  {
    path: 'list',
    component: ListProductComponent,
  },
];

@NgModule({
  declarations: [ListProductComponent, CreateProductComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductModule {}

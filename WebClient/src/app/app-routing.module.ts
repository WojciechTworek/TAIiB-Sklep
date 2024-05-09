import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductComponent } from './product/product.component';
import { OrderPositionComponent } from './order-position/order-position.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';

const routes: Routes = [
  {path: 'products', component:ProductComponent},
  {path: 'orderpos', component:OrderPositionComponent},
  {path: 'order', component:OrdersComponent},
  {path: 'basket', component:BasketComponent},
  {path: '', redirectTo: 'products', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

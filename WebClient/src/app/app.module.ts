import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { UserComponent } from './user/user.component';
import { ProductComponent } from './product/product.component';
import { OrderPositionComponent } from './order-position/order-position.component';

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent,
    BasketComponent,
    UserComponent,
    ProductComponent,
    OrderPositionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

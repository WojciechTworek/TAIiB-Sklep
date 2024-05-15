import { Product } from "./product.model";
import { OrderPosition } from "./order-position.model";

export interface Order {
    id: number;
    userId: number;
    date: Date;
    orderPositions: OrderPosition[];
  }
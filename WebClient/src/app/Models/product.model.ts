import { OrderPosition } from "./order-position.model";

export interface Product {
  id: number;
  name: string;
  price: number;
  image: string;
  isActive: boolean;
  orderPosition: OrderPosition;
}
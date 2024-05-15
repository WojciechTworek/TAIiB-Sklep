import { Product } from "./product.model";
import { Order } from "./order.model";

export interface OrderPosition {
    id: number;
    orderId: number;
    order: Order;
    amount: number;
    price: number | null;
    productId: number;
    products: Product[];
}
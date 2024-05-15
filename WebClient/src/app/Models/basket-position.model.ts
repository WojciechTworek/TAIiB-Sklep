import { Product } from "./product.model";
import { User } from "./user.model";

export interface BasketPosition {
    id: number;
    productId: number;
    product: Product;
    userId: number;
    user: User;
    amount: number;
}
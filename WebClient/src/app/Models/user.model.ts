import { Order } from "./order.model";
import { BasketPosition } from "./basket-position.model";

export enum Type {
    Admin,
    Casual
}

export interface User {
    id: number;
    login: string;
    password: string;
    type: Type;
    isActived: boolean;
    orders: Order[];
    basketPositions: BasketPosition[];
}
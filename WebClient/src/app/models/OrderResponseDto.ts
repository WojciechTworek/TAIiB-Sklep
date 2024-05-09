import { OrderPositionResponseDto } from "./OrderPositionResponseDto";

export interface OrderResponseDto {
    orderId: number;
    date: string;
    orderPositions: OrderPositionResponseDto[];
}
import { ProductResponseDto } from "./ProductResponseDto";

export interface OrderPositionResponseDto {
    price: number;
    amount: number;
    product: ProductResponseDto;
}
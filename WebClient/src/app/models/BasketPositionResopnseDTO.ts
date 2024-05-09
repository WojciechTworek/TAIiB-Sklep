import { ProductResponseDto } from "./ProductResponseDto";

export interface BasketPositionResponseDto {
    basketPositionId: number;
    amount: number;
    product: ProductResponseDto;
}
export interface ProductUpdateRequestDto {
    name: string | null;
    price: number | null;
    image: string | null;
    isActive: boolean | null;
}
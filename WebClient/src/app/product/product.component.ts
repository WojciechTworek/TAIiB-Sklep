import { Component, OnInit } from '@angular/core';
import { ProductService } from '../sklep.service'; // Zaimportuj serwis ProductService
import { ProductResponseDto } from '../models/ProductResponseDto';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: ProductResponseDto[]; // Deklaruj tablicę produktów

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProducts(); // Wywołaj funkcję pobierającą produkty przy inicjalizacji komponentu
  }

  getProducts(): void {
    this.productService.getProducts()
      .subscribe(products => this.products = products);
  }
}

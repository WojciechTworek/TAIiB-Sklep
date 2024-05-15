import { Component } from '@angular/core';
import { ProductsService } from '../Services/products.services';
import { ProductResponse } from '../product-response/product-response.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  public page: number = 0;
  public count: number = 10;
  public data: ProductResponse[] = [];

  constructor(private productsService: ProductsService) {
    this.loadData();
  }

  private loadData(): void {
    this.productsService.get({ page: this.page, count: this.count }).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  public onPaginationSubmit(): void {
    this.page += 1;
    this.loadData();
  }
}

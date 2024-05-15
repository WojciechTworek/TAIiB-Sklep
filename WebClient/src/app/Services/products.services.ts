import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponse } from '../product-response/product-response.component';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl = 'https://localhost:4200/api/products';

  constructor(private http: HttpClient) { }

  get(params: { page: number, count: number }): Observable<ProductResponse[]> {
    return this.http.get<ProductResponse[]>(this.apiUrl, {
      params: {
        page: params.page.toString(),
        count: params.count.toString()
      }
    });
  }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponse } from '../product-response/product-response.component';
import { ProductResponseDto } from '../Models/product-response.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl = 'https://localhost:7054/api/Product';

  constructor(private http: HttpClient) { }

  get(params: { page: number, count: number }): Observable<ProductResponseDto[]> {
    return this.http.get<ProductResponseDto[]>(this.apiUrl + "/" + params.page + "/" + params.count);
  }
}
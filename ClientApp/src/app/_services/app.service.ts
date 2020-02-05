import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { environment } from "../../environments/environment";
import { User, Book } from "../_models";

@Injectable({ providedIn: "root" })
export class AppService {
  items: Book[] = [];
  constructor(private http: HttpClient) {}

  addToCart(item: Book) {
    this.items.push(item);
  }

  getCartItems() {
    return this.items;
  }
}

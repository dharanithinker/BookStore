import { Component, OnInit } from "@angular/core";
import { Book } from "../_models";

@Component({
  selector: "app-cart",
  templateUrl: "./cart.component.html",
  styleUrls: ["./cart.component.css"]
})
export class CartComponent implements OnInit {
  cartItems: Book[] = [];
  constructor() {
    let book = JSON.parse(localStorage.getItem('_myCart'));
    this.cartItems.push(book);
  }

  ngOnInit() {}
}

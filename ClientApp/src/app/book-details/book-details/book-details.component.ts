import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Store, select } from "@ngrx/store";
import { BooksState } from "../../state/dashboard.state";
import { Book } from "../../_models";

@Component({
  selector: "app-book-details",
  templateUrl: "./book-details.component.html",
  styleUrls: ["./book-details.component.css"]
})
export class BookDetailsComponent implements OnInit {
  selectedBookId: number;
  selectedBook: Book;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private store: Store<{ books: BooksState }>
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.selectedBookId = +params.id;
    });

    this.store
      .select(state => state)
      .subscribe(data => {
        const storeBooks: Book[] = data.books.Books;
        const computedBook = storeBooks.filter(
          x => x.id === this.selectedBookId
        );
        this.selectedBook = computedBook[0];
      });
  }

  addToCart() {
    this.selectedBook.orderQuantity = 1;
    localStorage.setItem("_myCart", JSON.stringify(this.selectedBook));
    this.router.navigate(["/MyCart"]);
  }
}

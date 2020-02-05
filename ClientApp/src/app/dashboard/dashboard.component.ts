import { Component, OnDestroy } from "@angular/core";
import { first, map } from "rxjs/operators";
import { MatCardModule } from "@angular/material/card";

import { Book } from "../_models";
import { BookService, AuthenticationService } from "../_services";
import { Router, ActivatedRoute } from "@angular/router";
import { BooksState } from "../state/dashboard.state";
import { Store, select } from "@ngrx/store";
import { Observable, Subscription } from "rxjs";
import * as DashBoardActions from "../state/dashboard.action";

@Component({ templateUrl: "dashboard.component.html" })
export class DashboardComponent implements OnDestroy {
  loading = false;
  books: Book[];
  books$: Observable<BooksState>;
  BookSubscription: Subscription;
  constructor(
    private bookService: BookService,
    private route: ActivatedRoute,
    private router: Router,
    private store: Store<{ books: BooksState }>
  ) {
    this.books$ = store.pipe(select("books"));
  }

  ngOnInit() {
    this.loading = true;
    this.BookSubscription = this.books$
      .pipe(
        map(x => {
          if (x) {
            this.loading = false;
            this.books = x.Books;
          }
        })
      )
      .subscribe();
    this.store.dispatch(DashBoardActions.LoadBooksAction());
  }

  viewBook(selectedBook) {
    this.router.navigate(["/Details"], {
      queryParams: { id: selectedBook.id }
    });
  }

  ngOnDestroy() {
    if (this.BookSubscription) {
      this.BookSubscription.unsubscribe();
    }
  }
}

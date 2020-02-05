import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Action } from "@ngrx/store";
import { Observable, of } from "rxjs";
import { catchError, map, mergeMap } from "rxjs/operators";
import * as DashBoardActions from "../state/dashboard.action";
import { Book } from "../_models";

@Injectable()
export class DashboardEffects {
  constructor(private http: HttpClient, private action$: Actions) {}

  private ApiURL: string = "http://localhost:50074/api/Books/GetAllBooks";

  GetBooks$: Observable<Action> = createEffect(() =>
    this.action$.pipe(
      ofType(DashBoardActions.LoadBooksAction),
      mergeMap(action =>
        this.http.get(this.ApiURL).pipe(
          map((data: Book[]) => {
            return DashBoardActions.SuccessLoadBooksAction({ payload: data });
          }),
          catchError((error: Error) => {
            return of(DashBoardActions.ErrorBooksAction(error));
          })
        )
      )
    )
  );
}

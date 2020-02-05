import { Action, createReducer, on } from "@ngrx/store";
import * as DashBoardActions from "./dashboard.action";
import { initializeState, BooksState } from "./dashboard.state";
import { Book } from "../_models";

export const intialState = initializeState();

const reducer = createReducer(
  intialState,
  on(DashBoardActions.LoadBooksAction, state => state),
  on(
    DashBoardActions.SuccessLoadBooksAction,
    (state: BooksState, { payload }) => {
      return { ...state, Books: payload };
    }
  )
);

export function BooksReducer(state: BooksState | undefined, action: Action) {
  return reducer(state, action);
}

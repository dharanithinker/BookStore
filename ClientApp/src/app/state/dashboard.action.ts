import { createAction, props } from "@ngrx/store";
import { Book } from "../_models";

export const LoadBooksAction = createAction("[Books] - Load Books");

export const SuccessLoadBooksAction = createAction(
  "[Books] - Success Load Books",
  props<{ payload: Book[] }>()
);


export const ErrorBooksAction = createAction('[Books] - Error', props<Error>());
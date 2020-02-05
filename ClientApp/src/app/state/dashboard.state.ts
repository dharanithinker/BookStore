import { Book } from "../_models";

export class BooksState {
  Books: Array<Book>;
}

export const initializeState = (): BooksState => {
  return { Books: Array<Book>() };
};

import { Category } from "./category";

export class Book {
  id: number;
  title: string;
  subTitle: string;
  coverPicture: string;
  description: string;
  author: string;
  price: number;
  discount: number;
  category: Category;
  totalQuantity: number;
  orderQuantity: number;
}

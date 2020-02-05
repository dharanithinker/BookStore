import { Routes, RouterModule } from "@angular/router";

import { DashboardComponent } from "./dashboard";
import { LoginComponent } from "./login";
import { AuthGuard } from "./_helpers";
import { BookDetailsComponent } from "./book-details/book-details/book-details.component";
import { CartComponent } from "./cart/cart.component";

const routes: Routes = [
  { path: "", component: LoginComponent },
  { path: "login", component: LoginComponent },
  { path: "Home", component: DashboardComponent, canActivate: [AuthGuard] },
  {
    path: "Details",
    component: BookDetailsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "MyCart",
    component: CartComponent
  },
  // otherwise redirect to home
  { path: "**", redirectTo: "" }
];

export const appRoutingModule = RouterModule.forRoot(routes);

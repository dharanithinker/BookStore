import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { StoreModule } from "@ngrx/store";
// used to create fake backend

import { AppComponent } from "./app.component";
import { appRoutingModule } from "./app.routing";

import { JwtInterceptor, ErrorInterceptor } from "./_helpers";
import { DashboardComponent } from "./dashboard";
import { LoginComponent } from "./login";

import { MatCardModule } from "@angular/material/card";
import { BookDetailsComponent } from "./book-details/book-details/book-details.component";
import { BooksReducer } from "./state/dashboard.reducer";
import { DashboardEffects } from "./state/dashboard.effects";
import { EffectsModule } from "@ngrx/effects";
import { CartComponent } from "./cart/cart.component";
import { MatTableModule } from "@angular/material/table";

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    appRoutingModule,
    MatCardModule,
    MatTableModule,
    FormsModule,
    StoreModule.forRoot({ books: BooksReducer }),
    EffectsModule.forRoot([DashboardEffects])
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    BookDetailsComponent,
    CartComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

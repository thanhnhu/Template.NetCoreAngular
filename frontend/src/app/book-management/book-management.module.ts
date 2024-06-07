import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from "@angular/forms";

import { BookManagementRoutingModule } from './book-management-routing.module';
import { AddBookComponent } from './components/add-book/add-book.component';
import { BookDetailsComponent } from './components/book-details/book-details.component';
import { BooksListComponent } from './components/books-list/books-list.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BookManagementRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [
    AddBookComponent,
    BookDetailsComponent,
    BooksListComponent
  ],
  exports: [
    AddBookComponent,
    BookDetailsComponent,
    BooksListComponent
  ]
})
export class BookManagementModule { }

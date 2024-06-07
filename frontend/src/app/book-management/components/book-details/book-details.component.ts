import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/book-management/services/book.service';
import { Book } from 'src/app/book-management/models/book.model';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css'],
})
export class BookDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentBook: Book = {
    author: '',
    title: '',
    description: ''
  };

  error = '';
  message = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService
  ) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getBook(this.route.snapshot.params['id']);
    }
  }

  getBook(id: string): void {
    this.bookService.get(id).subscribe({
      next: (data) => {
        this.currentBook = data;
        console.log(data);
      },
      error: (e) => this.errorHandler(e)
    });
  }

  updateBook(): void {
    this.message = '';

    this.bookService
      .update(this.currentBook.id, this.currentBook)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message
            ? res.message
            : 'This book was updated successfully!';
        },
        error: (e) => this.errorHandler(e)
      });
  }

  deleteBook(): void {
    this.bookService.delete(this.currentBook.id).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/books']);
      },
      error: (e) => this.errorHandler(e)
    });
  }

  errorHandler(e: any) {
    this.error = e.message;
    //You can also throw the error to a global error handler
    //throw e;
  }
}

import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Book } from 'src/app/book-management/models/book.model';
import { BookService } from 'src/app/book-management/services/book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css'],
})
export class AddBookComponent implements OnInit {
  form: FormGroup = new FormGroup({
    author: new FormControl(''),
    title: new FormControl(''),
    description: new FormControl('')
  });
  submitted = false;
  error = '';

  constructor(private formBuilder: FormBuilder,
    private bookService: BookService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        author: [
          '',
          [
            Validators.required,
            Validators.minLength(1),
            Validators.maxLength(30)
          ]
        ],
        title: [
          '',
          [
            Validators.required,
            Validators.minLength(1),
            Validators.maxLength(50)
          ]
        ],
        description: [
          '',
          [
            Validators.maxLength(1000)
          ]
        ],
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.form.invalid) return;

    const data = this.form.value;
    this.bookService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        this.submitted = true;
      },
      error: (e) => this.errorHandler(e)
    });
  }

  newBook(): void {
    this.submitted = false;
    this.form.reset();
  }

  errorHandler(e: any) {
    this.error = e.message;
    //You can also throw the error to a global error handler
    //throw e;
  }
}

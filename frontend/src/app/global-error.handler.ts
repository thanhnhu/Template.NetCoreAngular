import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor() { }

  handleError(error: Error | HttpErrorResponse) {
    console.log('GlobalErrorHandler');
    console.error(error);
  }
}
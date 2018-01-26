import { Observable } from "rxjs/Observable";

import { CustomException } from "../models";

export class ApiErrorHandler {
  public static handleError(error: any) {
    var modelStateErrors: string = '';
    var serverError = error.json();

    let status = error["status"];

    if (status == 400) {
      for (var key in serverError) {
        if (serverError[key]) {
          modelStateErrors += serverError[key] + " ";
        }
      }
    }
    else {
      let customException = serverError as CustomException;
      modelStateErrors = customException.errorCode + " " + customException.message;
    }

    modelStateErrors = modelStateErrors == '' ? 'Server error' : modelStateErrors;
    return Observable.throw(modelStateErrors);
  }
}

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QueryDataService {

  constructor() { }
  private call = new BehaviorSubject({purpose: "initial", message: " "});

  /*
    It is still mystery for me how to pass data between unrelated components because
    this implementation seems like lots of trouble in the future and passing it
    child->parent->anotherChild is kinda hacky. Maybe not.
  */
  getCall = this.call.asObservable();
  setCall(purpose: string, message: any){
    this.call.next({purpose: purpose, message: message});
  }
}

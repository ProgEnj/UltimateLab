import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QueryDataService {

  constructor() { }
  private call = new BehaviorSubject({purpose: "initial", message: ""});

  getCall = this.call.asObservable();
  setCall(purpose: string, message: any){
    this.call.next({purpose: purpose, message: message});
  }


}

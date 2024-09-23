import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ControlCallService {

  constructor() { }
  private call = new BehaviorSubject("Initial call");
  getCall = this.call.asObservable();

  setCall(message: string) {
    this.call.next(message);
  }

}

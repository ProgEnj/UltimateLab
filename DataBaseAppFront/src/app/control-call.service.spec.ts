import { TestBed } from '@angular/core/testing';

import { ControlCallService } from './control-call.service';

describe('ControlCallService', () => {
  let service: ControlCallService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControlCallService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { MonsterDropServiceService } from './monster-drop-service.service';

describe('MonsterDropServiceService', () => {
  let service: MonsterDropServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonsterDropServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { MonsterWeaknessService } from './monster-weakness.service';

describe('MonsterWeaknessService', () => {
  let service: MonsterWeaknessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonsterWeaknessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

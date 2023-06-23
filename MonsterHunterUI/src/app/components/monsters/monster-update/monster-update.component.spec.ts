import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonsterUpdateComponent } from './monster-update.component';

describe('MonsterUpdateComponent', () => {
  let component: MonsterUpdateComponent;
  let fixture: ComponentFixture<MonsterUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MonsterUpdateComponent]
    });
    fixture = TestBed.createComponent(MonsterUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

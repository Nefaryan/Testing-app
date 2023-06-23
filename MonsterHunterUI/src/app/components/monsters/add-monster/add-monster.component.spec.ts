import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMonsterComponent } from './add-monster.component';

describe('AddMonsterComponent', () => {
  let component: AddMonsterComponent;
  let fixture: ComponentFixture<AddMonsterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddMonsterComponent]
    });
    fixture = TestBed.createComponent(AddMonsterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

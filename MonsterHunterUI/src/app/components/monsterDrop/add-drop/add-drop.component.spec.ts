import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDropComponent } from './add-drop.component';

describe('AddDropComponent', () => {
  let component: AddDropComponent;
  let fixture: ComponentFixture<AddDropComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddDropComponent]
    });
    fixture = TestBed.createComponent(AddDropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

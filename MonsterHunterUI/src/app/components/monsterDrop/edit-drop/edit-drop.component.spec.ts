import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDropComponent } from './edit-drop.component';

describe('EditDropComponent', () => {
  let component: EditDropComponent;
  let fixture: ComponentFixture<EditDropComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditDropComponent]
    });
    fixture = TestBed.createComponent(EditDropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

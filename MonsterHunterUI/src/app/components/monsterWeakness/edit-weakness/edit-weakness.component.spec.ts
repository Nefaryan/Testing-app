import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditWeaknessComponent } from './edit-weakness.component';

describe('EditWeaknessComponent', () => {
  let component: EditWeaknessComponent;
  let fixture: ComponentFixture<EditWeaknessComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditWeaknessComponent]
    });
    fixture = TestBed.createComponent(EditWeaknessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoResultBoxComponent } from './no-result-box.component';

describe('NoResultBoxComponent', () => {
  let component: NoResultBoxComponent;
  let fixture: ComponentFixture<NoResultBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoResultBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoResultBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

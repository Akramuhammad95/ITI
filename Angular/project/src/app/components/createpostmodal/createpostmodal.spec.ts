import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Createpostmodal } from './createpostmodal';

describe('Createpostmodal', () => {
  let component: Createpostmodal;
  let fixture: ComponentFixture<Createpostmodal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Createpostmodal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Createpostmodal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

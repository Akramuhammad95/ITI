import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Postslist } from './postslist';

describe('Postslist', () => {
  let component: Postslist;
  let fixture: ComponentFixture<Postslist>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Postslist]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Postslist);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

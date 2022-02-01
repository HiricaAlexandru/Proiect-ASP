import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaMotoareComponent } from './lista-motoare.component';

describe('ListaMotoareComponent', () => {
  let component: ListaMotoareComponent;
  let fixture: ComponentFixture<ListaMotoareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaMotoareComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaMotoareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

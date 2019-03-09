/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LocataireListComponent } from './locataire-list.component';

describe('LocataireListComponent', () => {
  let component: LocataireListComponent;
  let fixture: ComponentFixture<LocataireListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocataireListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocataireListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

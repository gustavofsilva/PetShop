/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PetShopComponent } from './PetShop.component';

describe('PetShopComponent', () => {
  let component: PetShopComponent;
  let fixture: ComponentFixture<PetShopComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetShopComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PetShopComponent } from './PetShop/PetShop.component';
import { NavComponent } from './nav/nav.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AnimalComponent } from './Animal/Animal.component';

@NgModule({
  declarations: [			
    AppComponent,
      PetShopComponent,
      NavComponent,
      AnimalComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,    
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

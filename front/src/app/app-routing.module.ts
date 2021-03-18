import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimalComponent } from './Animal/Animal.component';
import { PetShopComponent } from './PetShop/PetShop.component';

const routes: Routes = [
  {path: 'alojamentos', component: PetShopComponent},
  {path: 'animais', component: AnimalComponent},
  {path: '', redirectTo: 'alojamentos', pathMatch: 'full'},
  {path: '**', redirectTo: 'alojamentos', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

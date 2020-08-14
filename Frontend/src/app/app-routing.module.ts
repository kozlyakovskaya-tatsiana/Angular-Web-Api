import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MainComponent} from './main/main.component';
import {AutoparkComponent} from './autopark/autopark.component';
import {RulesComponent} from './rules/rules.component';
import {ContactComponent} from './contact/contact.component';
import {NotFoundComponent} from './not-found/not-found.component';
import {AddCarComponent} from './add-car/add-car.component';

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'autopark', component: AutoparkComponent},
  { path: 'rules', component: RulesComponent},
  { path: 'contact', component: ContactComponent},
  { path: 'addcar', component: AddCarComponent},
  { path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { ContactComponent } from './contact/contact.component';
import { RulesComponent } from './rules/rules.component';
import { AutoparkComponent } from './autopark/autopark.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CarForCategoryComponent } from './car-for-category/car-for-category.component';
import { CarCardComponent } from './car-card/car-card.component';
import { CarSectionComponent } from './car-section/car-section.component';
import { HeadComponent } from './head/head.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    ContactComponent,
    RulesComponent,
    AutoparkComponent,
    NotFoundComponent,
    CarForCategoryComponent,
    CarCardComponent,
    CarSectionComponent,
    HeadComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

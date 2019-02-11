import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RadioScaleComponent } from './components/radio-scale/radio-scale.component';
import { ItemsService } from './components/radio-scale/Item.service';
import { AddVariablesComponent } from './components/add-variables/add-variables.component';

@NgModule({
  declarations: [
    AppComponent,
    RadioScaleComponent,
    AddVariablesComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [ItemsService],
  bootstrap: [AppComponent]
})
export class AppModule { }

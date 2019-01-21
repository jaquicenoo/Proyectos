import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RadioScaleComponent } from './components/radio-scale/radio-scale.component';
import { ItemsService } from './components/radio-scale/Item.service';

@NgModule({
  declarations: [
    AppComponent,
    RadioScaleComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [ItemsService],
  bootstrap: [AppComponent]
})
export class AppModule { }

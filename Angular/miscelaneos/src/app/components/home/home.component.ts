import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  template: `
  <app-ng-style class="m-5"></app-ng-style>
  <app-css class="m-5"></app-css>
  <app-clases class="m-5"></app-clases>
  <p class="m-5" [appResaltado]="'orange'">hola mundo</p>
  <app-ng-switch class="m-5"></app-ng-switch>
  `,
  styles: []
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

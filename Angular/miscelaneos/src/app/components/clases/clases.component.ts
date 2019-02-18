import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clases',
  templateUrl: './clases.component.html',
  styleUrls: ['./stylos.css']
})
export class ClasesComponent implements OnInit {

  alert = 'alert-danger';
  loading = false;
  propiedades = {
    danger: true
  };
  constructor() { }

  ngOnInit() {
  }
  ejecutar() {
    this.loading = true;
    setTimeout(() => this.loading = false, 3000);
  }
  change($event) {
    if ($event.target.value !== 'value1') {
      $event.target.classList.remove('select');
    } else {
      $event.target.classList.add('select');
    }
  }
  blur($event) {
    if ($event.target.value.length > 3) {
      $event.target.classList.add('invalid');
    } else {
      $event.target.classList.remove('invalid');
    }
  }

}

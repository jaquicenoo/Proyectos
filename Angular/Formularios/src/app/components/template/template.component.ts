import { Component } from '@angular/core';
import { NgForm  } from '@angular/forms';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styles: [`
    .ng-invalid.ng-touched:not(form) {
      border: 1px solid red;
    }
  `]
})
export class TemplateComponent {

  usuario: Object = {
    nombre: null,
    apellido: null,
    correo: null,
    pais: 'COL',
    sexo: 'Maculino',
    acepta: true
  };

  paises = [{
    codigo: 'COL',
    nombre: 'Colombia'
  },
  {
    codigo: 'ESP',
    nombre: 'España'
  }];

  sexos: string[] = ['Masculino', 'Femenino'];

  constructor() { }

  guardar( forma: NgForm) {
    console.log('formulario guardado');
    console.log('ngForm:', forma);
    console.log('value:', forma.value);
  }
}

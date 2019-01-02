import { Component } from '@angular/core';
import { reject } from 'q';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  nombre = 'jhon';
  nombre2 = 'jhOn alexAnder quIceno oroZco';
  arreglo = [1, 2, 3, 4, 5, 6];
  PI = Math.PI;
  a = 0.234;
  salario = 1234.5;
  heroe = {
    nombre: 'logan',
    cleve: 'wolverine',
    edad: 500,
    direccion: {
      calle: 'primera',
      casa: '16'
    }
  };

  valorPromesa = new Promise((resolve) => {
    setTimeout( () => resolve('llego la data!'), 3500);
  });

  fecha = new Date();
  video = 'H9byzsH759M';
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent {
  mostrar = true;
  frase: any = {
    mensaje: 'Un gran poder requiere una gran responsabilidad',
    auto: 'Ben Parker'
  };

  personajes: string[] = ['Spiderman', 'venon', 'doctor octopus'];
}

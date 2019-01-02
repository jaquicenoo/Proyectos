import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeoresService, Heroe } from 'src/app/services/heroes.service';

@Component({
  selector: 'app-buscar',
  templateUrl: './buscar.component.html',
  styles: []
})
export class BuscarComponent implements OnInit {
  heroes: Heroe[] = [];
  constructor(private _activatedRouter: ActivatedRoute, private _heroesService: HeoresService) {
  }

  ngOnInit() {
    this._activatedRouter.params.subscribe(params => {
      this.heroes = this._heroesService.buscarHeroe(params['termino']);
    });
  }

}

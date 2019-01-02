import { Component, OnInit } from '@angular/core';
import { HeoresService, Heroe } from 'src/app/services/heroes.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html'
})
export class HeroesComponent implements OnInit {

  heroes: Heroe[] = [];
  constructor(private _heroesService: HeoresService) { }

  ngOnInit() {
    this.heroes = this._heroesService.getHeroes();
  }

}

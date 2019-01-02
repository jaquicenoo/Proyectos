import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Heroe, HeoresService } from '../../services/heroes.service';

@Component({
  selector: 'app-heroe',
  templateUrl: './heroe.component.html',
  styles: []
})
export class HeroeComponent implements OnInit {

  heroe: Heroe;

  constructor(private activatedRoute: ActivatedRoute, private _heroeService: HeoresService) {
    // observador
    this.activatedRoute.params.subscribe( params => {
      this.heroe = this._heroeService.getHeroe( params['id']);
    });
   }

  ngOnInit() {
  }

}

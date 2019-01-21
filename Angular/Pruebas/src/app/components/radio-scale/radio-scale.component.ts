import { Component, OnInit } from '@angular/core';
import { Item } from '../../shared/Item';
import { ItemsService } from '../radio-scale/Item.service';

@Component({
  selector: 'app-radio-scale',
  templateUrl: './radio-scale.component.html',
  styleUrls: ['./radio-scale.component.css']
})
export class RadioScaleComponent implements OnInit {

  ListItem: Item[] = [];
  ListGroup = [];
  GrupPercent = 0;
  GrupSize = 0;

  constructor(_servicio: ItemsService) {
    this.ListItem = _servicio.getItems();
    let arr = [];
    arr.push(this.ListItem[0]);
    for (let i = 1; i < this.ListItem.length; i++) {
      if (this.ListItem[i].Img === this.ListItem[i  - 1].Img ) {
        arr.push(this.ListItem[i]);
      } else {
        this.ListGroup.push(arr);
        arr = [];
        arr.push(this.ListItem[i]);
      }
    }
    this.ListGroup.push(arr);
    this.GrupSize = (100 / this.ListGroup.length );
    this.GrupPercent = (100 / this.ListItem.length) * this.GrupSize;
   }

  ngOnInit() {
  }

}

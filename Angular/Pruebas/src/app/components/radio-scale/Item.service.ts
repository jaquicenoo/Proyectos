import { Injectable } from '@angular/core';
import { Item } from '../../shared/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  ListItem: Item[] = [];
  constructor() {
    this.ListItem.push({
      Name: '1',
      Value: 1,
      Type: 'Text',
      Img: 'flame.jpg',
      Inter: 'dolor leve'
    });
    this.ListItem.push({
      Name: '2',
      Value: 2,
      Type: 'Text',
      Img: 'flame.jpg',
      Inter: 'dolor leve'
    });
    this.ListItem.push({
      Name: '3',
      Value: 3,
      Type: 'Text',
      Img: 'flame.jpg',
      Inter: 'dolor leve'
    });
    this.ListItem.push({
      Name: '4',
      Value: 4,
      Type: 'Text',
      Img: 'hum.png',
      Inter: 'dolor suave'
    });
    this.ListItem.push({
      Name: '5',
      Value: 5,
      Type: 'Text',
      Img: 'hum.png',
      Inter: 'dolor suave'
    });
    this.ListItem.push({
      Name: '6',
      Value: 6,
      Type: 'Text',
      Img: 'ubic.jpg',
      Inter: 'dolor moderado'
    });
    this.ListItem.push({
      Name: '7',
      Value: 7,
      Type: 'Text',
      Img: 'ubic.jpg',
      Inter: 'dolor moderado'
    });
    this.ListItem.push({
      Name: '8',
      Value: 8,
      Type: 'Text',
      Img: 'doc.png',
      Inter: 'dolor supreme'
    });
    this.ListItem.push({
      Name: '9',
      Value: 9,
      Type: 'Text',
      Img: 'world.png',
      Inter: 'dolor intenso'
    });
    this.ListItem.push({
      Name: '10',
      Value: 10,
      Type: 'Text',
      Img: 'world.png',
      Inter: 'dolor intenso'
    });
  }

  public getItems() {
    return this.ListItem;
  }
}

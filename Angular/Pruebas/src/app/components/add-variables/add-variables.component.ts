import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-add-variables',
  templateUrl: './add-variables.component.html',
  styleUrls: ['./add-variables.component.css']
})
export class AddVariablesComponent implements AfterViewInit {

  constructor(private elementRef: ElementRef) { }

  ngAfterViewInit() {
    this.elementRef.nativeElement.querySelector('#collapseOne')
                                  .addEventListener('hidden.bs.collapse', this.collapse.bind(this));
  }

  collapse () {

  }
}

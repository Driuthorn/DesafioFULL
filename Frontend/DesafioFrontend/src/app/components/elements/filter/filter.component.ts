import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent {

  @Input() label: string;
  @Input() placeholder: string;
  @Output() filter: EventEmitter<any> = new EventEmitter();

  filterInput: string;
  constructor() { 
    this.filterInput = '';
  }

  search() {
    this.filter.emit(this.filterInput);
  }
}

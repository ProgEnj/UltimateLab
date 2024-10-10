import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { TableData } from '../interfaces/table-data';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [],
  templateUrl: './display.component.html',
  styleUrl: './display.component.scss'
})
export class DisplayComponent implements OnChanges {
  placeholder: string = "#";
  @Input() dataSource: Array<any> = [];
  @Input() table: string = "";

  @Input() columnsToDisplay: Array<TableData> = [];

  ngOnChanges(changes: SimpleChanges): void {
    if(changes["table"])
    {
      this.dataSource = [];
    }
  }
}

import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { TableRowsService } from '../table-rows.service';
import { TableData } from '../interfaces/table-data';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [],
  templateUrl: './display.component.html',
  styleUrl: './display.component.scss'
})
export class DisplayComponent implements OnChanges {
  constructor(private rows: TableRowsService){}
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

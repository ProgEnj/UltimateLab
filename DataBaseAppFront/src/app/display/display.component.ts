import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { TableRowsService } from '../table-rows.service';

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

  columnsToDisplay: Array<string> = [];

  ngOnChanges(changes: SimpleChanges): void{
    if(changes["table"])
    {
      this.ChangeColumns();
    }
  }
  ChangeColumns():void{
    this.columnsToDisplay = this.rows.GetRows(this.table);
  }

}

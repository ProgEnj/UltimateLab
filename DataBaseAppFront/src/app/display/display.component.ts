import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [],
  templateUrl: './display.component.html',
  styleUrl: './display.component.scss'
})
export class DisplayComponent implements OnChanges {
  tablesRows: any =
    {
      students: ["id", "surname", "related_group", "lectern_id", "rating"],
      groups: ["id", "code", "lectern_id", "speciality_id"],
      lecterns: ["id", "faculty", "manager"],
      specialities: ["id", "code", "name", "field"]
    }
  @Input() dataSource: Array<any> = [];
  @Input() table: string = "";

  columnsToDisplay: Array<string> = this.tablesRows[this.table];

  ngOnChanges(changes: SimpleChanges): void{
    if(changes["table"])
    {
      this.ChangeColumns();
    }
  }
  ChangeColumns():void{
    this.columnsToDisplay = this.tablesRows[this.table];
  }

}

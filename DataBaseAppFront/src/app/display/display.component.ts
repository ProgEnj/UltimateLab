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
      Students: ["id", "surname", "related_group", "lectern_id", "rating"],
      Groups: ["id", "code", "lectern_id", "speciality_id"],
      Lecterns: ["id", "faculty", "manager"],
      Specialities: ["id", "code", "name", "field"]
    }
  @Input() dataSource: Array<any> = []; 
  @Input() table: string = "Lecterns";
  columnsToDisplay: Array<string> = this.tablesRows[this.table];
  ngOnChanges(changes: SimpleChanges): void{
    if(changes["table"])
    {
      this.ChangeSource();
    }
  }

  ChangeSource():void{
    this.columnsToDisplay = this.tablesRows[this.table];
  }

}

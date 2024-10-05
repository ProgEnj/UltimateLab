import { Component, inject, OnChanges, SimpleChanges } from '@angular/core';
import { DisplayComponent } from '../display/display.component';
import { HttpService } from '../http.service';
import { FormsModule } from '@angular/forms';
import { TableRowsService } from '../table-rows.service';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [DisplayComponent, FormsModule],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent {
  constructor(private http: HttpService, private rows: TableRowsService){}

  dataSource: Array<any> = [];
  table: string = "Choose table";
  queryType: string = "Choose query type";

  checkBoxOptions: Array<string> = [];
  columnstoDisplay: Array<any> = [];
  
  ExecuteQuery(){
    if(this.queryType == "RETRIEVE"){
      this.http.GetData("/api/get/" + this.table).subscribe(json => {this.dataSource = json;});
    }
  }

  onTableChange(event: any): void {
    this.columnstoDisplay = this.rows.GetRows(this.table).map((value) => ({label: value, isChecked: true}));
    this.checkBoxOptions = Array.from(this.rows.GetRows(this.table));
  }

  onCheckChange(value: string, index: number): void {
    if(value != "0" && this.checkBoxOptions.includes(value)) {
      this.checkBoxOptions.fill("0", index, index + 1);
      this.columnstoDisplay[index].isChecked = false;
      /*
      
        Very strange Angular behaviour. Apparently(i made a research) there is no way to render elements
        with @for without trackby statement (because of optimisation blah blah). So even if i have a small
        amount of elements i still need to provide some unique property of an item.

        My checkboxes were a simple array of strings, so when the table was changed, the checkbox array was simply
        substituted to a different array and indexes were the same. Then @for rendered a new array
        and kept the state of the checkboxes. So if the table was students and an id box was unchecked,
        then the table became Groups, the id box kept to be unchecked.

        Now the checkboxes have a isChecked property, so when the table changes it updates this property
        to true and the state of the checkboxes changes. Two way bounding doesn't help and yes,
        checkboxes are broken in angular

      */
    }   
    else {
      this.checkBoxOptions[index] = this.columnstoDisplay[index].label;
      //this.columnstoDisplay[index].isChecked = true; this code doesn't make sense because we
      //just need to track if checkbox was unchecked
    }
  }
}

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

  checkBoxOptions: Array<any> = [];
  columnstoDisplay: Array<string> = [];
  
  ExecuteQuery(){
    if(this.queryType == "RETRIEVE"){
      this.http.GetData("/api/get/" + this.table).subscribe(json => {this.dataSource = json;});
    }
  }

  onTableChange(value: string): void {
    this.columnstoDisplay = this.rows.GetRows(this.table);
    this.checkBoxOptions = this.rows.GetRows(this.table);
  }

  onCheckChange(value: string): void {
    if(this.checkBoxOptions.includes(value)) {
      this.checkBoxOptions = this.checkBoxOptions.filter((item) => item != value);
    }
    else {
      this.checkBoxOptions.push(value);
    }
  }

}

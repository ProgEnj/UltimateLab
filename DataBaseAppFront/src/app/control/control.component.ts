import { Component } from '@angular/core';
import { DisplayComponent } from '../display/display.component';
import { HttpService } from '../http.service';
import { FormsModule } from '@angular/forms';
import { TableRowsService } from '../table-rows.service';
import { QueryDataService } from '../query-data.service';
import { Subscription } from 'rxjs';
import { TableData } from '../interfaces/table-data';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [DisplayComponent, FormsModule],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent {
  constructor(private http: HttpService, private rows: TableRowsService, private queryData: QueryDataService) {
    this.subscription = queryData.getCall.subscribe(x => this.onQueryData(x));
  }

  subscription: Subscription;

  dataSource: Array<any> = [];
  tableOption: string = "Choose table";
  queryOption: string = "Choose query type";

  checkBoxOptions: Array<TableData> = [];
  columnstoDisplay: Array<TableData> = [];

  //formData: any;
  textAreaShow: boolean = false;
  sqlQuery: string = "";
  
  ExecuteQuery(){
    if(this.queryOption == "RETRIEVE"){
      this.http.GetData("/" + this.tableOption).subscribe(json => {this.dataSource = json;});
    }
    this.textAreaShow = true;
    this.sqlQuery = this.buildSqlQuery();
  }

  onTableChange(event: Event): void {
    this.columnstoDisplay = this.rows.GetRows(this.tableOption, true);
    this.checkBoxOptions = Array.from(this.rows.GetRows(this.tableOption, true));
    console.log(this.columnstoDisplay);
    console.log(this.checkBoxOptions);
    this.queryData.setCall("table", this.tableOption)
  }

  onQueryChange(event: Event): void {
    this.queryData.setCall("query", this.queryOption);
  }

  onCheckChange(index: number): void {
    var checkBox = this.checkBoxOptions[index];
    var columns = this.columnstoDisplay[index];
    if(checkBox.isShown) {
      checkBox.isShown = false
      columns.isShown = false;
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
      checkBox.isShown = true;
      //columns.isShown = true; this code doesn't even make sense because we
      //just need to track if checkbox was unchecked
    }
  }

  buildSqlQuery(): string{
    var command: string = "";
    var columns: Array<TableData> = this.checkBoxOptions.filter(x => x.isShown == true);
    console.log(columns);
    switch (this.queryOption) {
      case "CREATE":
        //command = `INSERT INTO ${this.tableOption} (${columns.join(', ')}) VALUES (${Object.values(this.formData).join(', ')});`
        break;
      case "RETRIEVE":
        command = `SELECT (${columns.join(', ')}) FROM ${this.tableOption};`
        break;
      case "UPDATE":
        //var values = Object.values(this.formData);
        //console.log(values);
        //var whereID = values.pop();
        //command = `UPDATE ${this.tableOption} SET ${values.map((x, i) => `${columns[i]} = ${x}, `)} WHERE id = ${whereID}`
        break;
      case "DELETE":
        command = `DELETE;`
        break;
    }
    return command;
  }

  downloadFile(){
    var file = new Blob([this.sqlQuery], {type: "text/plain"});
    var a = document.createElement('a');
    a.href = URL.createObjectURL(file);
    a.download = "query.txt";
    a.click();
  }

  // I should make this as queryData interface or make query-data implementation simpler
  onQueryData(data: any) {
    switch (data.purpose) {
      case "formData":
        //this.formData = data.message;
        break;
    
      default:
        break;
    }

  }
}

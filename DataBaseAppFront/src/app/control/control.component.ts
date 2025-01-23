import { Component, Input, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { TableComponent } from '../table/table.component';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [ TableComponent, FormComponent ],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent implements OnInit {
  constructor(private http: HttpService, private router: ActivatedRoute) {}

  ngOnInit(): void {
      this.priority = this.router.snapshot.paramMap.get('priority');
      console.log(this.priority);
  }

  dataSource: Array<any> = [];
  headerSource: Array<any> = [];

  tableOption: string = "Choose table";
  queryOption: string = "Choose query type";

  priority: string | null = "1";

  formData: any;
  whereField: string = "";
  @Input() whereId?: number;

  textAreaShow: boolean = false;
  sqlQuery: string = "";

  CloneTo2DB(): void {
    this.http.GetData("/db2/tables").subscribe();
    this.dataSource.forEach(x => this.http.PostData("/" + this.tableOption, x).subscribe());
  }

  ConnectToDB(): void {
    this.http.GetData("/db").subscribe();
  }

  ConnectToDB2(): void {
    this.http.GetData("/db2").subscribe();
  }

  ExecuteQuery(queryOption: string){
      switch (queryOption) {
        case "RETRIEVE":
          this.RetrieveQuery();
          break;
        case "CREATE":
          this.http.PostData("/" + this.tableOption, this.formData).subscribe(x => this.RetrieveQuery());
          break;
        case "UPDATE":
          let columns: Array<string> = this.headerSource.filter(x => x.isShown == true && x.label !== "id").map(x => x.label);
          let data: Array<string> = Object.values(this.formData).map((x, i) => `${columns[i]} = '${x}'`);
          this.http.UpdateData(this.tableOption, this.whereId!, data).subscribe(x => this.RetrieveQuery());
          break;
        case "DELETE":
          this.http.DeleteData(this.tableOption, this.whereId!).subscribe(x => this.RetrieveQuery());
          break
        case "Task1":
          let id = this.dataSource[this.whereId! - 1]["groupId"];
          this.http.UpdateDataProductPrice(id).subscribe(x => this.RetrieveQuery());
          break
        case "Task3":
          this.RetrieveQuery();
          this.http.GetData("/products/amount", this.whereField).subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
          break
        case "Task4":
          this.RetrieveQuery();
          this.http.GetData("/purchases/sum", this.whereField).subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
          break
        case "DbInfo":
          this.RetrieveQuery();
          this.http.GetData("/dbinfo", "").subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
          break
        case "TablesInfo":
          this.RetrieveQuery();
          this.http.GetData("/tablesinfo", "").subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
          break
        case "Enqueue":
          this.http.GetData(`/${this.tableOption}/enqueued`, this.whereField + `&priority=${this.priority}`).subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
          break
        case "Resolve":
          this.http.GetData("/resolve").subscribe();
          break
        default:
          break;
      }
  }

  RetrieveQuery(): void {
    this.http.GetData("/" + this.tableOption, this.whereField).subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
    this.BuildSqlQuery();
  }

  setID(event: any): void {
    this.whereId = event.id;
  }

  setData(event: any): void {
    this.formData = event;
  }

  setWhereField(event: any): void {
    this.whereField = event;
  }

  onTableChange(event: any): void {
    this.tableOption = event.target.value;
      this.http.GetData("/" + this.tableOption).subscribe(json => {this.headerSource = json.columns.map((x:any) => ({label: x, isShown: true})); this.dataSource = json.data});
  }

  onQueryChange(event: any): void {
    this.queryOption = event.target.value;
  }

  onCheckChange(index: number): void {
    let foo = Object.create(this.headerSource);
    let column = foo[index];
    if(column.isShown) {
      column.isShown = false;
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
      column.isShown = true;
      //this code doesn't even make sense for checkboxes update because we
      //just need to track if checkbox was unchecked
    }
    this.headerSource = foo;
  }

  BuildSqlQuery(): string {
    let command: string = "";
    let columns: Array<string> = this.headerSource.filter(x => x.isShown == true && x.label !== "id").map(x => x.label);
    switch (this.queryOption) {
      case "CREATE":
        command = `INSERT INTO ${this.tableOption} (${columns.join(', ')}) VALUES (${Object.values(this.formData).join(', ')});`;
        break;
      case "RETRIEVE":
        command = `SELECT (${columns.join(', ')}) FROM ${this.tableOption};`;
        break;
      case "UPDATE":
        command = `UPDATE ${this.tableOption} SET ${Object.values(this.formData).map((x, i) => `${columns[i]} = ${x}`)} WHERE id = ${this.whereId}`;
        break;
      case "DELETE":
        command = `DELETE ${this.tableOption} WHERE id = ${this.whereId}`;
        break;
    }
    this.sqlQuery = command;
    this.textAreaShow = true;
    return command;
  }

  downloadFile() {
    let file = new Blob([this.sqlQuery], {type: "text/plain"});
    let a = document.createElement('a');
    a.href = URL.createObjectURL(file);
    a.download = "query.txt";
    a.click();
  }
}

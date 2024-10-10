import { Component } from '@angular/core';
import { FormControl, FormArray, ReactiveFormsModule, Validators, FormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { HttpService } from '../http.service';
import { TableRowsService } from '../table-rows.service';
import { QueryDataService } from '../query-data.service';
import { Subscription } from 'rxjs';
import { TableData } from '../interfaces/table-data';


@Component({
  selector: 'app-sender',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './sender.component.html',
  styleUrl: './sender.component.scss'
})
export class SenderComponent {
  subscription: Subscription;
  form: FormGroup;
  constructor(private http: HttpService, private rows: TableRowsService, private queryData: QueryDataService, private formBuilder: FormBuilder) {
    this.subscription = this.queryData.getCall.subscribe(x => this.onQueryData(x));
    this.form = this.formBuilder.group({
      items: this.formBuilder.array([])
    });
  }
  get items() {
    return this.form.get('items') as FormArray;
  }

  columnsToDisplay: Array<TableData> = [];
  table: string = "";
  queryType: string = "";
  whereId?: number;

  onTableChange() {
    this.columnsToDisplay = this.columnsToDisplay.filter(x => x.label !== "id");
    if(this.queryType !== "DELETE"){
      for (const element of this.columnsToDisplay) {
        var control = this.formBuilder.group({}).addControl(element.label, new FormControl(''));
        this.items.push(control);
      }
    }
  }


  onSubmit() {
    if(this.queryType !== "DELETE") {
      //this.queryData.setCall("formData", this.formBuilder.());
    }
    if(this.queryType == "DELETE" || this.queryType == "UPDATE" && this.whereId !== undefined) {
      this.queryData.setCall("whereID", this.whereId)
    }
    //this.http.PostData(`/${this.table}`, this.form.getRawValue()).subscribe(x => console.log(x));
  }

  onQueryData(data: any) {
    switch (data.purpose) {
      case "table":
        this.table = data.message;
        this.columnsToDisplay = this.rows.GetRows(this.table);
        this.onTableChange();
        break;
      case "query":
        this.queryType = data.message;
        break;
      case "columns":
        this.columnsToDisplay = data.message;
        console.log(this.columnsToDisplay);
        this.onTableChange();
        break;
    
      default:
        break;
    }
  }
}

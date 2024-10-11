import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { HttpService } from '../http.service';
import { TableRowsService } from '../table-rows.service';
import { QueryDataService } from '../query-data.service';
import { Subscription } from 'rxjs';
import { TableData } from '../interfaces/table-data';
import { NgFor } from '@angular/common'; 
// Maybe I'm dumb, but i just cannot understand how to reach same result with @for
// because trackBy drives me mad, I just cannot understand how i am suppose to have unique thing on each
// thing in this world and why I am not able to just re render things


@Component({
  selector: 'app-sender',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  templateUrl: './sender.component.html',
  styleUrl: './sender.component.scss'
})
export class SenderComponent {
  subscription: Subscription;
  constructor(private http: HttpService, private rows: TableRowsService, private queryData: QueryDataService, private fb: FormBuilder) {
    this.subscription = this.queryData.getCall.subscribe(x => this.onQueryData(x));
  }

  columnsToDisplay: Array<TableData> = [];
  table: string = "";
  queryType: string = "";
  whereId?: number;
  form = new FormGroup({});

  onTableChange() {
    this.form = this.fb.group({});
    this.columnsToDisplay = this.columnsToDisplay.filter(x => x.label !== "id");
    if(this.queryType !== "DELETE"){
      this.columnsToDisplay.filter(x => x.isShown !== false).forEach(x => {this.form.addControl(x.label, this.fb.control('', Validators.required))})
    }
  }

  onSubmit(event: any) {
    if(this.queryType !== "DELETE") {
      this.queryData.setCall("formData", this.form.getRawValue());
    }
    if(this.queryType == "DELETE" || this.queryType == "UPDATE") {
      this.whereId = event.target.where.value;
      console.log(this.whereId);
      this.queryData.setCall("whereId", this.whereId);
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
        this.onTableChange();
        break;
    
      default:
        break;
    }
  }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators, FormsModule } from '@angular/forms';
import { HttpService } from '../http.service';
import { TableRowsService } from '../table-rows.service';
import { QueryDataService } from '../query-data.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-sender',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './sender.component.html',
  styleUrl: './sender.component.scss'
})
export class SenderComponent {
  subscription: Subscription;
  constructor(private http: HttpService, private rows: TableRowsService, private queryData: QueryDataService) {
    this.subscription = this.queryData.getCall.subscribe(x => this.onQueryData(x));
  }

  table: string = "";
  queryType: string = "";
  form = new FormGroup({});
  columnsToDisplay: any = [];

  onTableChange() {
    this.columnsToDisplay = this.rows.GetRows(this.table).filter(x => x.label !== "id");
    if(this.queryType !== "DELETE"){
      this.columnsToDisplay.forEach(((x: any) => this.form.addControl(x.label, new FormControl('', Validators.required))));
      if (this.queryType == "UPDATE") {
        this.form.addControl("whereID", new FormControl('', Validators.required));
        console.log("Im here");
      }
    }
    else {
      this.form.addControl("whereID", new FormControl('', Validators.required));
    }
  }

  onSubmit( ) {
    this.queryData.setCall("formData", this.form.getRawValue());
    //this.http.PostData(`/${this.table}`, this.form.getRawValue()).subscribe(x => console.log(x));
  }

  onQueryData(data: any) {
    switch (data.purpose) {
      case "table":
        this.table = data.message;
        this.onTableChange();
        break;
      case "query":
        this.queryType = data.message;
        break;
    
      default:
        break;
    }
  }

}

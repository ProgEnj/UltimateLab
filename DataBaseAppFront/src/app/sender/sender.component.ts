import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators, FormsModule } from '@angular/forms';
import { HttpService } from '../http.service';
import { TableRowsService } from '../table-rows.service';


@Component({
  selector: 'app-sender',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './sender.component.html',
  styleUrl: './sender.component.scss'
})
export class SenderComponent {
  constructor(private http: HttpService, private rows: TableRowsService) {}
  table: string = "";
  form = new FormGroup({});
  columnsToDisplay: any = [];

  onTableChange(){
    this.columnsToDisplay = this.rows.GetRows(this.table).filter(x => x.label !== "id");
    this.columnsToDisplay.forEach(((x: any) => this.form.addControl(x.label, new FormControl('', Validators.required))));
  }

  onSubmit(){
    this.http.PostData(`/${this.table}`, this.form.getRawValue()).subscribe(x => console.log(x));
  }
}

import { Component, inject } from '@angular/core';
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
  constructor(private http: HttpService){}

  private rows = inject(TableRowsService)
  dataSource: Array<any> = [];
  table: string = "Choose table";
  queryType: string = "Choose query type";
  columnstoDisplay: Array<string> = ["biba", "boba", "antilopa", "asdf", "asdfas", "asdfasd"];
  
  ExecuteQuery(){
    if(this.queryType == "RETRIEVE"){
      this.http.GetData("/api/get/" + this.table).subscribe(json => {this.dataSource = json; console.log(json)});
      console.log("/api/get/" + this.table);
    }
  }
}

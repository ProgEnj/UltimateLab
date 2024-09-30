import { Component } from '@angular/core';
import { DisplayComponent } from '../display/display.component';
import { HttpService } from '../http.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [DisplayComponent, FormsModule],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent {
  constructor(private http: HttpService){}
  dataSource: Array<any> = [];
  table: string = "Choose table";
  queryType: string = "Choose query type";
  
  ExecuteQuery(){
    if(this.queryType == "RETRIEVE"){
      this.http.GetData("/api/get/" + this.table).subscribe(json => {this.dataSource = json; console.log(json)});
      console.log("/api/get/" + this.table);
    }
  }
}

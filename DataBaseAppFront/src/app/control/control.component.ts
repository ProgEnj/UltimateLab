import { Component } from '@angular/core';
import { DisplayComponent } from '../display/display.component';
import { HttpService } from '../http.service';
import { FormsModule } from '@angular/forms';
import { Group } from '../interfaces/group';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [DisplayComponent, FormsModule],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent {
  constructor(private http: HttpService){}
  dataSource: Array<any> = [{id: 1, faculty: "biba", manager:"boba"}];
  table: string = "Choose table";
  queryType: string = "Choose query type";
  
  ExecuteQuery(){
    //this.http.GetData("/weatherforecasts").subscribe(json => {this.dataSource = json})
    console.log(this.table);
  }
}

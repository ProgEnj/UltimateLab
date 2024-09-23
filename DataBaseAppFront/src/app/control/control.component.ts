import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { DisplayComponent } from "../display/display.component";
import { HttpService } from '../http.service';

@Component({
  selector: 'app-control',
  standalone: true,
  imports: [DisplayComponent, MatButton],
  templateUrl: './control.component.html',
  styleUrl: './control.component.scss'
})
export class ControlComponent {
  constructor(private http: HttpService){}
  dataSource: object[] = [];
  mockSource: object[] = [
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
    {id: 1, temp: 20, date: "123123123", summary: "aboba"},
  ];
  
  GetAll(){
    this.http.GetData("/weatherforecasts").subscribe(json => {this.dataSource = json})
  }
}

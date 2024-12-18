import { Component } from '@angular/core';
import { TableComponent } from '../table/table.component';
import { ControlComponent } from '../control/control.component';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [ TableComponent, FormComponent, ControlComponent ],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent {
  headerSource: Array<any> = [
    {label: "id", isShown: true},
    {label: "surname", isShown: true},
    {label: "related_group", isShown: true},
    {label: "join_year", isShown: true},
    {label: "rating", isShown: true},
  ]
}

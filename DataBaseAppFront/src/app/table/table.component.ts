import { Component, EventEmitter, Input, output } from '@angular/core';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {
  placeholder: string = "#";
  @Input() dataSource: Array<any> = [];
  @Input() headerSource: Array<any> = [];
  checkedRow = output<any>();

  onRadioCheck(data: any) {
    this.checkedRow.emit(data);
  }
}

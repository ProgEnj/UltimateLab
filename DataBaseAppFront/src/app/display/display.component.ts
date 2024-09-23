import { Component, Input } from '@angular/core';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './display.component.html',
  styleUrl: './display.component.scss'
})
export class DisplayComponent {
  columnsToDisplay: string[] = ["id", "temp", "date", "summary"];
  @Input() dataSource: object[] = []; 

}

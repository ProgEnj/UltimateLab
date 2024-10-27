import { Injectable } from '@angular/core';
import { TableData } from './interfaces/table-data';

// interface TableDataList {
//   students: Array<TableData>,
//   groups: Array<TableData>,
//   lecterns: Array<TableData>,
//   specialities: Array<TableData>,
// }

@Injectable({
  providedIn: 'root'
})
export class TableRowsService {
  private tableRows: any =
    { 
      students: [
        {label: "id", type: "number", isShown: true},
        {label: "surname", type: "text", isShown: true},
        {label: "related_group", type: "number", isShown: true}, 
        {label: "join_year", type: "number", isShown: true},
        {label: "rating", type: "number", isShown: true},
      ],
      groups: [
        {label: "id", type: "number", isShown: true},
        {label: "code", type: "number", isShown: true},
        {label: "lectern_id", type: "number", isShown: true}, 
        {label: "speciality_id", type: "number", isShown: true},
      ],
      lecterns: [
        {label: "id", type: "number", isShown: true},
        {label: "faculty", type: "text", isShown: true},
        {label: "manager", type: "text", isShown: true}, 
      ],
      specialities: [
        {label: "id", type: "number", isShown: true},
        {label: "code", type: "number", isShown: true},
        {label: "name", type: "text", isShown: true}, 
        {label: "field", type: "text", isShown: true}, 
      ],
    };
  GetRows(table: string): Array<TableData>{
    return this.tableRows[table] as Array<TableData>;    
  }
}

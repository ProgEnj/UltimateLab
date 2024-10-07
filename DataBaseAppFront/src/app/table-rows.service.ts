import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TableRowsService {
  private tableRows: any =
    {
      students: [
        {label: "id", type: "number"},
        {label: "surname", type: "text"},
        {label: "related_group", type: "number"}, 
        {label: "lectern_id", type: "number"},
        {label: "rating", type: "number"},
      ],
      groups: [
        {label: "id", type: "number"},
        {label: "code", type: "number"},
        {label: "lectern_id", type: "number"}, 
        {label: "speciality_id", type: "number"},
      ],
      lecterns: [
        {label: "id", type: "number"},
        {label: "faculty", type: "text"},
        {label: "manager", type: "text"}, 
      ],
      specialities: [
        {label: "id", type: "number"},
        {label: "code", type: "number"},
        {label: "name", type: "text"}, 
        {label: "field", type: "text"}, 
      ],
    };
  GetRows(table: string): Array<any>{
    return this.tableRows[table];
  }
}

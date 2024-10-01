import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TableRowsService {
  private tableRows: any =
    {
      students: ["id", "surname", "related_group", "lectern_id", "rating"],
      groups: ["id", "code", "lectern_id", "speciality_id"],
      lecterns: ["id", "faculty", "manager"],
      specialities: ["id", "code", "name", "field"]
    };
  GetRows(table: string): Array<string>{
    return this.tableRows[table];
  }
}

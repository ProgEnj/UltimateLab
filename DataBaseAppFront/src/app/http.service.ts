import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient){}

  private host: string = "http://localhost:5233/api";

  GetData(url: string, whereOption: string = ""): Observable<any>{
    return this.http.get<any>(this.host + "/get" + url + `?whereOption=${whereOption}`);
  }

  PostData(url:string, data: any){
    return this.http.post<any>(this.host + "/post" + url, data);
  }

  DeleteData(table:string, id:number){
    return this.http.delete(this.host + `/delete?table=${table}&id=${id}`);
  }

  UpdateData(table:string, id:number, data:Array<string>){
    return this.http.put(this.host + `/update?table=${table}&id=${id}`, data);
  }
}

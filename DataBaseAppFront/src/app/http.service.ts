import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private host: string = "http://localhost:5233/api";

  GetData(url: string): Observable<any>{
    return this.http.get<any>(this.host + "/get" + url);
  }
  PostData(url:string, data: any){
    return this.http.post<any>(this.host + "/post" + url, data);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Weatherforecast } from './weatherforecast';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private host: string = "http://localhost:5233";

  GetData(url: string): Observable<any>{
    return this.http.get<any>(this.host + url);
  }
  PostData(url:string, forecast: Weatherforecast){
    return this.http.post<any>(this.host + url, forecast).subscribe();
  }
}

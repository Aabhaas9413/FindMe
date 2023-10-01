import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  path: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getSearchedUserList(keyword: string):Observable<any>{
    return this.http.get(this.path + "getSearchResults/" + keyword);
  }
}

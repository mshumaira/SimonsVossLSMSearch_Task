import { Injectable } from '@angular/core';
import { BaseService } from '../Base/base.service';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable()
export class SearchTextService {
  //RestAPI reference for Searching the text
  SEARCH_ACTION_URL = "api/LSMSearch/LSMSearchText?searchText=";
  
  // Service injected
  constructor(private baseService: BaseService, private http: HttpClient) { }

  // Fetch search result by calling the LSMSearchApp API using baseService
  getSearchResult(searchText: string) {
    const url = this.SEARCH_ACTION_URL + searchText;
    return this.baseService.get(url).then((res) =>{
      return res;
    })
  }

}

import { Injectable } from '@angular/core';
import { BaseService } from '../Base/base.service';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable()
export class SearchTextService {
  SEARCH_ACTION_URL = "api/LSMSearch/LSMSearchText?searchText=";

  constructor(private baseService: BaseService, private http: HttpClient) { }

  getSearchResult(searchText: string) {
    const url = this.SEARCH_ACTION_URL + searchText;
    return this.baseService.get(url).then((res) =>{
      return res;
    })
  }

}

import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class BaseService {
  //Extract the baseURL of the RestAPI server
  BASE_URL: string = environment.BASE_URL
  constructor(private httpClient: HttpClient) { }

  
  // Fetch search result and return Promise
  get(url: string){
    return this.httpClient.get(this.BASE_URL+url).toPromise();
  }
}
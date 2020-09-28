import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class BaseService {
  BASE_URL: string = environment.BASE_URL
  constructor(private httpClient: HttpClient) { }

  get(url: string){
    return this.httpClient.get(this.BASE_URL+url).toPromise();
  }
}
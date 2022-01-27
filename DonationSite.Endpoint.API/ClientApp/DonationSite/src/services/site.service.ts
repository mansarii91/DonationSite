import { GlobalConst } from './../global_const';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as Interfaces from '../interfaces/site';

@Injectable({
  providedIn: 'root',
})
export class SiteService {
  public mainUrl: string;
  public constructor(private http: HttpClient) {
    this.mainUrl = GlobalConst.MAIN_URL_Site;
  }
  public getAllSiteList(
    take: number,
    skip: number
  ): Observable<Interfaces.Site[]> {
    let url = `${this.mainUrl}/${take}/${skip}`;
    return this.http.get<Interfaces.Site[]>(url).pipe();
  }
}

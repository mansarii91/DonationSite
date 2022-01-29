import { GlobalConst } from './../global_const';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as Interfaces from '../interfaces/site';

@Injectable({
  providedIn: 'root',
})
export class SiteService {
  private mainUrl: string;
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

  public getTotalCount(): Observable<number> {
    let url = `${this.mainUrl}`;
    return this.http.get<number>(url).pipe();
  }

  public getSiteById(id: number): Observable<Interfaces.UpdateSite> {
    let url = `${this.mainUrl}/${id}`;
    return this.http.get<Interfaces.UpdateSite>(url).pipe();
  }

  public deleteSite(id: number): Observable<boolean> {
    let url = `${this.mainUrl}/${id}`;
    return this.http.delete<boolean>(url).pipe();
  }

  public addSite(model: Interfaces.CreateSite): Observable<boolean> {
    let url = `${this.mainUrl}`;

    return this.http
      .post<boolean>(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
      .pipe();
  }

  public updateSite(model: Interfaces.UpdateSite): Observable<boolean> {
    let url = `${this.mainUrl}`;

    return this.http
      .put<boolean>(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
      .pipe();
  }
}

import { GlobalConst } from '../global_const';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as Interfaces from '../interfaces/donate';

@Injectable({
  providedIn: 'root',
})
export class DonateService {
  private mainUrl: string;
  public constructor(private http: HttpClient) {
    this.mainUrl = GlobalConst.MAIN_URL_Donate;
  }

  public Submit(model: Interfaces.Donate): Observable<boolean> {
    let url = `${this.mainUrl}`;

    return this.http
      .post<boolean>(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
      .pipe();
  }
}

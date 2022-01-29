import { GlobalConst } from '../global_const';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {
  BaseServiceParam,
  ReportSiteServiceParam,
} from '../interfaces/serviceParam';
import * as InterfaceDonator from '../interfaces/reportDonator';
import * as InterfaceReport from '../interfaces/reportSite';

@Injectable({
  providedIn: 'root',
})
export class ReportService {
  private mainUrl: string;
  public constructor(private http: HttpClient) {
    this.mainUrl = GlobalConst.MAIN_URL_Report;
  }

  /// view list of donation for a site
  public GetDonationSiteReport(
    params: ReportSiteServiceParam
  ): Observable<InterfaceDonator.ReportDonator[]> {
    let url = `${this.mainUrl}/${params.siteId}/${params.take}/${params.skip}`;
    return this.http.get<InterfaceDonator.ReportDonator[]>(url).pipe();
  }

  //get count
  public GetDonationSiteReportTotalCount(siteId: number): Observable<number> {
    let url = `${this.mainUrl}/${siteId}`;
    return this.http.get<number>(url).pipe();
  }
  //=============================================================================================== */

  /// view list of all sites with his total donation
  public GetReportSites(
    params: BaseServiceParam
  ): Observable<InterfaceReport.ReportSite[]> {
    let url = `${this.mainUrl}/${params.take}/${params.skip}`;
    return this.http.get<InterfaceReport.ReportSite[]>(url).pipe();
  }

  //get count
  public GetReportSitesTotalCount(): Observable<number> {
    let url = `${this.mainUrl}/`;
    return this.http.get<number>(url).pipe();
  }
}

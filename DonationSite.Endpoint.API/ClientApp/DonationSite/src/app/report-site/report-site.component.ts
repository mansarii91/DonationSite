import { ReportSite } from './../../interfaces/reportSite';
import { ReportService } from './../../services/report.service';
import { Component, OnInit } from '@angular/core';
import * as BaseParamsModel from './../../models/serviceParams';
import * as BaseParamInterface from '../../interfaces/serviceParam';

@Component({
  selector: 'app-report-site',
  templateUrl: './report-site.component.html',
  styleUrls: ['./report-site.component.css'],
})
export class ReportSiteComponent implements OnInit {
  result: ReportSite[];
  totalCount: number = 0;
  hasError: boolean = false;
  constructor(private reportService: ReportService) {
    this.result = [];
  }

  ngOnInit(): void {
    this.getTotalCount();
    this.loadData();
  }

  loadData() {
    let params: BaseParamInterface.BaseServiceParam = new BaseParamsModel.BaseParams();
    params.skip = 0;
    params.take = 1000;
    this.reportService.GetReportSites(params).subscribe(
      (result: ReportSite[]) => {
        this.result = result;
      },
      (error: string) => {
        this.hasError = true;
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }

  getTotalCount() {
    this.reportService.GetReportSitesTotalCount().subscribe(
      (result: number) => {
        this.totalCount = result;
      },
      (error: string) => {
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }

  showSiteID(id: number) {
    alert(id);
  }
}

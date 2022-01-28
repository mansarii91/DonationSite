import { ReportSite } from './../../interfaces/reportSite';
import { ReportService } from './../../services/report.service';
import { Component, OnInit } from '@angular/core';
import * as BaseParamsModel from './../../Models/serviceParams';
import * as BaseParamInterface from '../../interfaces/baseServiceParam';

@Component({
  selector: 'app-report-site',
  templateUrl: './report-site.component.html',
  styleUrls: ['./report-site.component.css'],
})
export class ReportSiteComponent implements OnInit {
  result: ReportSite[];
  frameworkComponents: any;
  api: any;

  constructor(private reportService: ReportService) {
    this.result = [];
  }

  ngOnInit(): void {
    let params: BaseParamInterface.BaseServiceParam = new BaseParamsModel.BaseParams();
    params.skip = 0;
    params.take = 1000;
    this.reportService.GetReportSites(params).subscribe(
      (result: ReportSite[]) => {
        this.result = result;
      },
      (error: string) => {
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }
}

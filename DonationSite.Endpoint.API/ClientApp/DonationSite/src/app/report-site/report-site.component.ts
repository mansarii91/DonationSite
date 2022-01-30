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
  //-------------------------------------------------------
  result: ReportSite[];
  hasError: boolean = false;
  totalCount: number = 0;
  page = 1;
  itemsPerPage = 5;

  //=======================================================
  constructor(private reportService: ReportService) {
    this.result = [];
  }

  ngOnInit(): void {
    this.getTotalCount();
    this.loadData(1);
  }

  loadData(page: number) {
    let params: BaseParamInterface.BaseServiceParam = new BaseParamsModel.BaseParams();
    params.skip = (page - 1) * this.itemsPerPage;
    params.take = this.itemsPerPage;
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

  onPagingChange(page: any) {
    this.loadData(page);
  }
}

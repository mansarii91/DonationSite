import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportService } from 'src/services/report.service';
import * as BaseParamsModel from '../../models/serviceParams';
import * as BaseParamInterface from '../../interfaces/serviceParam';
import { ReportDonator } from 'src/interfaces/reportDonator';

@Component({
  selector: 'app-report-site-donation',
  templateUrl: './report-site-donation.component.html',
  styleUrls: ['./report-site-donation.component.css'],
})
export class ReportSiteDonationComponent implements OnInit {
  //************************************************** */
  result: ReportDonator[] = [];
  hasError: boolean = false;
  totalCount: number = 0;
  page = 1;
  itemsPerPage = 5;
  siteId = 0;
  //************************************************** */
  constructor(private router: ActivatedRoute, private service: ReportService) {}

  ngOnInit(): void {
    this.siteId = this.router.snapshot.params['id'];
    this.getTotalCount(this.siteId);
    this.loadData(this.siteId, 1);
  }

  loadData(siteId: number, page: number) {
    let params: BaseParamInterface.ReportSiteServiceParam = new BaseParamsModel.ReportSiteServiceModel();
    params.skip = (page - 1) * this.itemsPerPage;
    params.take = this.itemsPerPage;
    params.siteId = siteId;
    this.service.GetDonationSiteReport(params).subscribe(
      (result: ReportDonator[]) => {
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

  getTotalCount(siteId: number) {
    this.service.GetDonationSiteReportTotalCount(siteId).subscribe(
      (result: number) => {
        this.totalCount = result;
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

  onPagingChange(page: any, siteId: number) {
    this.loadData(siteId, page);
  }
}

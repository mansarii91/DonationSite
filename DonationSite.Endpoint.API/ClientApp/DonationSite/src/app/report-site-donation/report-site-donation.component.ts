import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportService } from 'src/services/report.service';
import * as BaseParamsModel from '../../models/serviceParams';
import * as BaseParamInterface from '../../interfaces/baseServiceParam';
import { ReportDonator } from 'src/interfaces/reportDonator';

@Component({
  selector: 'app-report-site-donation',
  templateUrl: './report-site-donation.component.html',
  styleUrls: ['./report-site-donation.component.css'],
})
export class ReportSiteDonationComponent implements OnInit {
  //******************* */
  result: ReportDonator[] = [];
  hasError: boolean = false;

  //************************************************** */
  constructor(private router: ActivatedRoute, private service: ReportService) {}

  ngOnInit(): void {
    let siteId: number = this.router.snapshot.params['id'];
    this.loadData(siteId);
  }

  loadData(siteId: number) {
    let params: BaseParamInterface.ReportSiteServiceParam = new BaseParamsModel.ReportSiteServiceModel();
    params.skip = 0;
    params.take = 1000;
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
}
